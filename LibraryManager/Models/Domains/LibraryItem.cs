using System;

namespace LibraryManager.Models.Domains
{
    public class LibraryItem
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }

        public bool IsBorrowable { get; set; }
        public string Borrow { get; set; }
        public DateTime BorrowDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
