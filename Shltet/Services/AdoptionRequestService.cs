using Shelter.Models;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class AdoptionRequestService : IAdoptionRequestService
    {
        private readonly IAdoptionRequestRepo _adoptionRepo;

        public AdoptionRequestService(IAdoptionRequestRepo adoptionRepo)
        {
            _adoptionRepo = adoptionRepo;
        }

        public async Task<IEnumerable<AdoptionRequest>> GetAllRequestsAsync()
        {
            return await _adoptionRepo.GetAsync();
        }

        public async Task<AdoptionRequest?> GetRequestByIdAsync(int id)
        {
            return await _adoptionRepo.GetOneAsync(expression: r => r.Id == id);
        }

        public async Task CreateRequestAsync(AdoptionRequest request)
        {
            await _adoptionRepo.CreateAsync(request);
            await _adoptionRepo.CommitAsync();
        }

        public async Task UpdateRequestAsync(AdoptionRequest request)
        {
            _adoptionRepo.Edit(request);
            await _adoptionRepo.CommitAsync();
        }

        public async Task DeleteRequestAsync(AdoptionRequest request)
        {
            _adoptionRepo.Delete(request);
            await _adoptionRepo.CommitAsync();
        }
    }
}
