using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shelter.Models;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        [ValidateNever]
        public Shelter? ShelterAccount { get; set; }

        public int PetCategoryId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public PetCategory? PetCategory { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }

    public enum PetStatus
    {
        Available,
        Adopted,
        Pending
    }
}
