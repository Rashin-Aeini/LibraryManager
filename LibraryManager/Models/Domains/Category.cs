using System.Collections.Generic;

namespace LibraryManager.Models.Domains
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<LibraryItem> LibraryItems { get; set; }
    }
}
