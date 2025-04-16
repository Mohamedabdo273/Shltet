using Shelter.Models;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class SupportRequestService : ISupportRequestService
    {
        private readonly ISupportRequestRepo _supportRepo;

        public SupportRequestService(ISupportRequestRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }

        public async Task<IEnumerable<SupportRequest>> GetAllSupportRequestsAsync()
        {
            return await _supportRepo.GetAsync();
        }

        public async Task<SupportRequest?> GetSupportRequestByIdAsync(int id)
        {
            return await _supportRepo.GetOneAsync(expression: r => r.Id == id);
        }

        public async Task CreateSupportRequestAsync(SupportRequest request)
        {
            await _supportRepo.CreateAsync(request);
            await _supportRepo.CommitAsync();
        }

        public async Task UpdateSupportRequestAsync(SupportRequest request)
        {
            _supportRepo.Edit(request);
            await _supportRepo.CommitAsync();
        }

        public async Task DeleteSupportRequestAsync(SupportRequest request)
        {
            _supportRepo.Delete(request);
            await _supportRepo.CommitAsync();
        }
    }
}
