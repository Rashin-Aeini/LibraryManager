using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models.ViewModels.Category
{
    public class CreateCategory
    {
        [Required]
        public string Name { get; set; }
    }
}
