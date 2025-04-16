using Shelter.Models;

namespace Shltet.Services.IServices
{
    public interface IAdoptionRequestService
    {
        Task<IEnumerable<AdoptionRequest>> GetAllRequestsAsync();
        Task<AdoptionRequest?> GetRequestByIdAsync(int id);
        Task CreateRequestAsync(AdoptionRequest request);
        Task UpdateRequestAsync(AdoptionRequest request);
        Task DeleteRequestAsync(AdoptionRequest request);
    }
}
