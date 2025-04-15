using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Publisher;
using Bookstore.Repositories;

namespace Bookstore.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<int> CreatePublisherAsync(CreatePublisher_DTO createPublisherDto)
        {
           var publisher = _mapper.Map<Publisher>(createPublisherDto);
            return await _publisherRepository.AddAsync(publisher);
        }

        public async Task<bool> DeletePublisherAsync(int id)
        {
           return await _publisherRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Publisher_DTO>> GetAllPublishersAsync()
        {
            List<Publisher_DTO> publishers = new List<Publisher_DTO>();
            var fetchedPublishers = await _publisherRepository.GetAllAsync();
            _mapper.Map(fetchedPublishers, publishers);
            return publishers;
        }

        public async Task<Publisher_DTO> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.FindByIdAsync(id);
            return _mapper.Map<Publisher_DTO>(publisher);
        }

        public async Task<bool> UpdatePublisherAsync(UpdatePublisher_DTO updatedPublisherDto)
        {
            var publisher = _mapper.Map<Publisher>(updatedPublisherDto);
            return await _publisherRepository.UpdateAsync(publisher);
        }
    }
}
