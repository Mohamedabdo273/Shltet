using Shelter.Models;

namespace Shltet.Services.IServices
{
    public interface ISupportRequestService
    {
        Task<IEnumerable<SupportRequest>> GetAllSupportRequestsAsync(int ShelterID);
        Task<SupportRequest?> GetSupportRequestByIdAsync(int id);
        Task CreateSupportRequestAsync(SupportRequest request);
        Task UpdateSupportRequestAsync(SupportRequest request);
        Task DeleteSupportRequestAsync(SupportRequest request);
    }
}
