using Microsoft.AspNetCore.Identity;

namespace LibraryManager.Models.Domains
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
