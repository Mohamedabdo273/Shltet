using Shltet.Modles;

namespace Shelter.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }

        public string? AdopterId { get; set; }
        public ApplicationUser? Adopter { get; set; }

        public int PetId { get; set; }
        public Pet? Pet { get; set; }

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
