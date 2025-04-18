using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shltet.Modles;
using System.Text.Json.Serialization;

namespace Shelter.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }


        public string? AdopterId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ApplicationUser? Adopter { get; set; }

        public int PetId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Pet? Pet { get; set; }

        public int ShelterId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Shltet.Modles.Shelter? Shelter { get; set; }
        public AdoptionRequestStatus? Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? InterviewDate { get; set; }
    }


    public enum AdoptionRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
