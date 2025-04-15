using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Book;
using Bookstore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper, IBookAuthorRepository bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookAuthorRepository = bookAuthorRepository;

        }

        public async Task<int> AddBookAsync(CreateBook_DTO createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            await _bookRepository.AddAsync(book);

            if (createBookDto.AuthorIds != null && createBookDto.AuthorIds.Count > 0)
            {
                foreach (var authorId in createBookDto.AuthorIds)
                {
                    var bookAuthor = new BookAuthor
                    {
                        BookId = book.Id,
                        AuthorId = authorId
                    };
                    await _bookAuthorRepository.AddAsync(bookAuthor);
                }
            }
            return book.Id;

        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book_DTO>> GetAllBooksAsync()
        {
            List<Book_DTO> books = new List<Book_DTO>();
            var fetchedBooks = await _bookRepository.GetAllAsync();
            _mapper.Map(fetchedBooks, books);
            return books;
        }

        public async Task<IEnumerable<Book_DTO>> GetAllBooksDetailedAsync(bool deletedBooks = false)
        {
            var fetchedBooks = await _bookRepository.GetAllBooksWithIncludesAsync();

            // Eğer silinmiş kitaplar istenmiyorsa, sadece aktif olanları filtrele
            if (!deletedBooks)
            {
                fetchedBooks = fetchedBooks
                    .Where(b => b.DeletedAt == null || b.Status != Enums.Status.Deleted)
                    .ToList();
            }

            var books = _mapper.Map<List<Book_DTO>>(fetchedBooks);
            return books;
        }

        public async Task<Book_DTO> GetBookByIdAsync(int id)
        {
            var bookEntity = await _bookRepository.FindByIdAsync(id);
            return _mapper.Map<Book_DTO>(bookEntity);
        }
        public async Task<BookDetail_DTO?> GetBookDetailByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdWithIncludesAsync(id);
            if (book == null) return null;

            return _mapper.Map<BookDetail_DTO>(book);
        }

        public async Task<IEnumerable<Book_DTO>> SearchBooksAsync(string keyword)
        {
            string loweredKeyword = keyword.ToLower();

            var filteredBooks = await _bookRepository.GetFilteredListAsync(
                select: b => new Book_DTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    CoverImage = b.CoverImage,
                    PublicationYear = b.PublicationYear,
                    EditionNumber = b.EditionNumber,
                    CoverText = b.CoverText,
                    CategoryName = b.Category.CategoryName,
                    PublisherName = b.Publisher.PublisherName,
                    AuthorNames = b.BookAuthors.Select(ba => ba.Author.FullName).ToList()
                },
                where: b =>
                    b.Status != Enums.Status.Deleted && (
                        b.Title.ToLower().Contains(loweredKeyword) ||
                        b.CoverText.ToLower().Contains(loweredKeyword) ||
                        b.Category.CategoryName.ToLower().Contains(loweredKeyword) ||
                        b.Publisher.PublisherName.ToLower().Contains(loweredKeyword) ||
                        b.BookAuthors.Any(ba => ba.Author.FullName.ToLower().Contains(loweredKeyword))
                    ),
                include: q => q
                    .Include(b => b.Category)
                    .Include(b => b.Publisher)
                    .Include(b => b.BookAuthors)
                        .ThenInclude(ba => ba.Author)
            );

            return filteredBooks;
        }


        public async Task<bool> UpdateBookAsync(UpdateBook_DTO updateBookDto)
        {
            return await _bookRepository.UpdateBookWithAuthorsAsync(updateBookDto);
        }
    }
}
