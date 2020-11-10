using Microsoft.AspNetCore.Identity;

namespace Reactivities.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        
    }
}