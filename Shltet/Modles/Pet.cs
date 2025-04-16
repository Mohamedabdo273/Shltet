using Shelter.Models;

namespace Shltet.Modles
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public int Age { get; set; }
        public string? MedicalHistory { get; set; }
        public PetStatus Status { get; set; }

        public int ShelterAccountId { get; set; }
        public ApplicationUser? ShelterAccount { get; set; }

        public int PetCategoryId { get; set; }
        public PetCategory? PetCategory { get; set; }

        // Navigation
        //public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }
    public enum PetStatus
    {
        Available,
        Adopted,
        Pending
    }
}
