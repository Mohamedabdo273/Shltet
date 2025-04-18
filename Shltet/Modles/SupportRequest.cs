using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shltet.Modles;
using System.Text.Json.Serialization;

namespace Shelter.Models
{
    public class SupportRequest
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ApplicationUser? User { get; set; }

        public int ShelterId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Shltet.Modles.Shelter? Shelter { get; set; }

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
