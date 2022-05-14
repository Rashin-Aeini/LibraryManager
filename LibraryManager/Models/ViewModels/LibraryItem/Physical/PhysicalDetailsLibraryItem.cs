namespace LibraryManager.Models.ViewModels.LibraryItem.Physical
{
    public class PhysicalDetailsLibraryItem : BaseLibraryItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public override Domains.LibraryItem MapGetter()
        {
            return new Domains.LibraryItem();
        }

        public override void MapSetter(Domains.LibraryItem entry)
        {
            Id = entry.Id;
            Title = entry.Title;
            Type = entry.Type;
            Author = entry.Author;
            Pages = entry.Pages ?? 0;
            IsBorrowable = entry.IsBorrowable;
            CategoryId = entry.CategoryId;
        }
    }
}
