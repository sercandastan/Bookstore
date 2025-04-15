using Bookstore.Models.DTOs.Book;

namespace Bookstore.Services.BookService
{
    public interface IBookService
    {
        public Task<IEnumerable<Book_DTO>> GetAllBooksAsync();

        public Task<int> AddBookAsync(CreateBook_DTO createBookDto);

        public Task<IEnumerable<Book_DTO>> GetAllBooksDetailedAsync(bool deleted = false);

        public Task<Book_DTO> GetBookByIdAsync(int id);

        public Task<BookDetail_DTO> GetBookDetailByIdAsync(int id);

        public Task<bool> DeleteBookAsync(int id);

        public Task<bool> UpdateBookAsync(UpdateBook_DTO updateBookDto);

        public  Task<IEnumerable<Book_DTO>> SearchBooksAsync(string keyword);


    }
}
