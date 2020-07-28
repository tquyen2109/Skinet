using Microsoft.AspNetCore.Identity;

namespace Core.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}