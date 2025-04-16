using Shltet.Modles;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class ShelterService : IShelterService
    {
        private readonly IshelterRepo _shelterRepo;

        public ShelterService(IshelterRepo shelterRepo)
        {
            _shelterRepo = shelterRepo;
        }

        public async Task<IEnumerable<Modles.Shelter>> GetAllSheltersAsync()
        {
            return await _shelterRepo.GetAsync();
        }

        public async Task<Modles.Shelter?> GetShelterByIdAsync(int id)
        {
            return await _shelterRepo.GetOneAsync(expression: s => s.Id == id);
        }

        public async Task CreateShelterAsync(Modles.Shelter shelter)
        {
            await _shelterRepo.CreateAsync(shelter);
            await _shelterRepo.CommitAsync();
        }

        public async Task UpdateShelterAsync(Modles.Shelter shelter)
        {
            _shelterRepo.Edit(shelter);
            await _shelterRepo.CommitAsync();
        }

        public async Task DeleteShelterAsync(Modles.Shelter shelter)
        {
            _shelterRepo.Delete(shelter);
            await _shelterRepo.CommitAsync();
        }
    }
}
