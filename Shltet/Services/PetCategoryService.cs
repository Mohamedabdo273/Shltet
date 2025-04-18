using Shltet.Modles;
using Shltet.Repository.IRepo;
using Shltet.Services.IServices;

namespace Shltet.Services
{
    public class PetCategoryService : IPetCategoryService
    {
        private readonly IPetCategoryRepo _categoryRepo;

        public PetCategoryService(IPetCategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<PetCategory>> GetAllCategoriesAsync(int shelterId)
        {
            return await _categoryRepo.GetAsync(expression:e=>e.ShelterId==shelterId);
        }

        public async Task<PetCategory?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetOneAsync(expression: c => c.Id == id);
        }

        public async Task CreateCategoryAsync(PetCategory category)
        {
            await _categoryRepo.CreateAsync(category);
            await _categoryRepo.CommitAsync();
        }

        public async Task UpdateCategoryAsync(PetCategory category)
        {
            _categoryRepo.Edit(category);
            await _categoryRepo.CommitAsync();
        }

        public async Task DeleteCategoryAsync(PetCategory category)
        {
            _categoryRepo.Delete(category);
            await _categoryRepo.CommitAsync();
        }
    }
}
