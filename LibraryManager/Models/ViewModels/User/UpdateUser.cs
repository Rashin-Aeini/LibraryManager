using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models.ViewModels.User
{
    public class UpdateUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
