using Microsoft.AspNetCore.Identity;

namespace Shltet.Modles
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        
        public int ShelterId { get; set; }
        public Shltet.Modles.Shelter? Shelter { get; set; }

    }
}
