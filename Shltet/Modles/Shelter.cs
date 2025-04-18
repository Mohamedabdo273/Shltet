using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shelter.Models;
using System.Text.Json.Serialization;

namespace Shltet.Modles
{
    public class Shelter
    {
        public int Id { get; set; }
        public string? ShelterName { get; set; }
        public string? Location { get; set; }
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }

        // Suggestion (Optional): Navigation properties for easier queries
        [JsonIgnore]
        [ValidateNever]
        public ICollection<Pet>? Pets { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ICollection<PetCategory>? Categories { get; set; }
        public ICollection<SupportRequest>? SupportRequests { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ICollection<AdoptionRequest>? AdoptionRequests { get; set; }
    }

}
