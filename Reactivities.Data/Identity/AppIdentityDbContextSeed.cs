using System.Linq;
using System.Threading.Tasks;
using Reactivities.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace  Reactivities.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}