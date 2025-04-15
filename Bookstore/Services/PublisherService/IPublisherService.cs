using Bookstore.Models.DTOs.Publisher;

namespace Bookstore.Services.PublisherService
{
    public interface IPublisherService
    {
        public Task<IEnumerable<Publisher_DTO>> GetAllPublishersAsync();
       
        public Task<int> CreatePublisherAsync(CreatePublisher_DTO createPublisherDto);

        public Task<bool> UpdatePublisherAsync(UpdatePublisher_DTO updatePublisherDto);

        public Task<Publisher_DTO> GetPublisherByIdAsync(int id);

        public Task<bool> DeletePublisherAsync(int id);

    }
}
