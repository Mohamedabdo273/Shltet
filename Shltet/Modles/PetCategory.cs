using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace Shltet.Modles
{
    public class PetCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int ShelterId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Shelter? Shelter { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public ICollection<Pet>? Pets { get; set; }
    }

}
