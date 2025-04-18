﻿using Shltet.Modles;

namespace Shltet.Services.IServices
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync(int ShelterId);
        Task<Pet?> GetPetByIdAsync(int id);
        Task CreatePetAsync(Pet pet);
        Task UpdatePetAsync(Pet pet);
        Task DeletePetAsync(Pet pet);
    }
}
