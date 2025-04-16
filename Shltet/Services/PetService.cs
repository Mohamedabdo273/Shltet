using Shltet.Modles;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepo _petRepo;

        public PetService(IPetRepo petRepo)
        {
            _petRepo = petRepo;
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _petRepo.GetAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _petRepo.GetOneAsync(expression: p => p.Id == id);
        }

        public async Task CreatePetAsync(Pet pet)
        {
            await _petRepo.CreateAsync(pet);
            await _petRepo.CommitAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            _petRepo.Edit(pet);
            await _petRepo.CommitAsync();
        }

        public async Task DeletePetAsync(Pet pet)
        {
            _petRepo.Delete(pet);
            await _petRepo.CommitAsync();
        }
    }
}
