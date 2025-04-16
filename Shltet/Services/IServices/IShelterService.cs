namespace Shltet.Services.IServices
{
    public interface IShelterService
    {
        Task<IEnumerable<Modles.Shelter>> GetAllSheltersAsync();
        Task<Modles.Shelter?> GetShelterByIdAsync(int id);
        Task CreateShelterAsync(Modles.Shelter shelter);
        Task UpdateShelterAsync(Modles.Shelter shelter);
        Task DeleteShelterAsync(Modles.Shelter shelter);
    }
}
