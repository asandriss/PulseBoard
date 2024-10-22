using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class User : IdentityUser
    {
        public string? SteamProfileName { get; set; }

        public long? SteamAccountId { get; set; }
    }
}
