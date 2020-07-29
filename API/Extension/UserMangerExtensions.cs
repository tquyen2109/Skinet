using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extension
{
    public static class UserMangerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
             var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

             return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);

        }
        public static async Task<AppUser> FindByEmailFromClaimsPrincipal (this UserManager<AppUser> input, ClaimsPrincipal user)
         {
             var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
         }
    }

    
}