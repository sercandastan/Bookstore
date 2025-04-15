using Bookstore.Models.DTOs.Author;

namespace Bookstore.Services.AuthorService
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author_DTO>> GetAllAuthorsAsync();

        public Task<int> CreateAuthorAsync(CreateAuthor_DTO createAuthorDto);

        public Task<bool> UpdateAuthorAsync(UpdateAuthor_DTO updateAuthorDto);

        public Task<bool> DeleteAuthorAsync(int id);

        public Task<Author_DTO> GetAuthorByIdAsync (int id);


    }
}
