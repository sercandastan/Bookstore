using Bookstore.Data;
using Bookstore.Enums;
using Bookstore.Models;
using Bookstore.Models.DTOs.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bookstore.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly BookstoreDbContext _context;
        public BookRepository(BookstoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooksWithIncludesAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .ToListAsync();
        }
        public async Task<Book?> GetBookByIdWithIncludesAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.Id == id && b.Status != Status.Deleted);
        }
        public async Task<bool> UpdateBookWithAuthorsAsync(UpdateBook_DTO updateDto)
        {
            var book = await _context.Books
                .Include(b => b.BookAuthors)
                .FirstOrDefaultAsync(b => b.Id == updateDto.Id);

            if (book == null)
                return false;

            // Book alanlarını güncelle
            book.Title = updateDto.Title;
            book.Price = updateDto.Price;
            book.PublicationYear = updateDto.PublicationYear;
            book.EditionNumber = updateDto.EditionNumber;
            book.CoverText = updateDto.CoverText;
            book.PublisherId = updateDto.PublisherId;
            book.CategoryId = updateDto.CategoryId;
            if (!string.IsNullOrEmpty(updateDto.CoverImage))
                book.CoverImage = updateDto.CoverImage;

            book.UpdatedAt = DateTime.Now;
            book.Status = Status.Updated;

            // ⛔ Eski yazar ilişkilerini kaldır
            _context.BookAuthors.RemoveRange(book.BookAuthors);

            // ✅ Yeni yazar ilişkilerini ekle
            foreach (var authorId in updateDto.AuthorIds)
            {
                _context.BookAuthors.Add(new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = authorId
                });
            }

            return await _context.SaveChangesAsync() > 0;
        }


    }
}
