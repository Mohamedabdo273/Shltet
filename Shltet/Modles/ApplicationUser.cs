using Microsoft.AspNetCore.Identity;

namespace Shltet.Modles
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
