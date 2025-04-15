using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Author;
using Bookstore.Repositories;
using Bookstore.Services.BookService;

namespace Bookstore.Services.AuthorService
{
    public class AuthorService : IAuthorService
      
    {
        private readonly IAuthorRepository _authorRepository;

        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAuthorAsync(CreateAuthor_DTO createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            return await _authorRepository.AddAsync(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Author_DTO>> GetAllAuthorsAsync()
        {
            List<Author_DTO> authors = new List<Author_DTO>();
            var fetchedAuthors = await _authorRepository.GetAllAsync();
            _mapper.Map(fetchedAuthors, authors);
            return authors;
        }

        public async Task<Author_DTO> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.FindByIdAsync(id);
            return _mapper.Map<Author_DTO>(author);

        }

        public async Task<bool> UpdateAuthorAsync(UpdateAuthor_DTO updateAuthorDto)
        {
            var author = _mapper.Map<Author>(updateAuthorDto);
            return await _authorRepository.UpdateAsync(author);

        }
    }
}
