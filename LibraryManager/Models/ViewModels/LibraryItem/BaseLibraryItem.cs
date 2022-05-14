namespace LibraryManager.Models.ViewModels.LibraryItem
{
    public abstract class BaseLibraryItem
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public bool IsBorrowable { get; set; }

        public abstract Domains.LibraryItem MapGetter();
        public abstract void MapSetter(Domains.LibraryItem entry);
    }
}
