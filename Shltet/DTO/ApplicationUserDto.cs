using System.ComponentModel.DataAnnotations;

namespace Shltet.DTO
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        public int? shelterID { get; set; } = 0;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
    }
}
