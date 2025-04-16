using Shltet.Modles;

namespace Shelter.Models
{
    public class SupportRequest
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? Subject { get; set; }
        public string? Message { get; set; }
        public SupportRequestStatus? Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
    public enum SupportRequestStatus
    {
        Open,
        InProgress,
        Closed
    }
}
