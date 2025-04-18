using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shltet.Modles;
using System.Text.Json.Serialization;

namespace Shelter.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ApplicationUser Receiver { get; set; }

        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }

}
