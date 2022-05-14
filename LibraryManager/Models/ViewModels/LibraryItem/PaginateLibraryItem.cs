namespace LibraryManager.Models.ViewModels.LibraryItem
{
    public class PaginateLibraryItem : BaseLibraryItem
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override Domains.LibraryItem MapGetter()
        {
            return new Domains.LibraryItem();
        }

        public override void MapSetter(Domains.LibraryItem entry)
        {
            Id = entry.Id;
            Type = entry.Type;
            Title = entry.Title;
            CategoryId = entry.CategoryId;
            IsBorrowable = entry.IsBorrowable;
        }
    }
}
