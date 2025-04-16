using Shltet.Modles;

namespace Shltet.Services.IServices
{
    public interface IPetCategoryService
    {
        Task<IEnumerable<PetCategory>> GetAllCategoriesAsync();
        Task<PetCategory?> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(PetCategory category);
        Task UpdateCategoryAsync(PetCategory category);
        Task DeleteCategoryAsync(PetCategory category);
    }
}
