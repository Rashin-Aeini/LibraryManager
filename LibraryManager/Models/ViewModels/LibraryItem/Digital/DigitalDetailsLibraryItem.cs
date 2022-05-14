namespace LibraryManager.Models.ViewModels.LibraryItem.Digital
{
    public class DigitalDetailsLibraryItem : BaseLibraryItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int RunTimeMinutes { get; set; }

        public override Domains.LibraryItem MapGetter()
        {
            return new Domains.LibraryItem();
        }

        public override void MapSetter(Domains.LibraryItem entry)
        {
            Id = entry.Id;
            Title = entry.Title;
            Type = entry.Type;
            RunTimeMinutes = entry.RunTimeMinutes ?? 0;
            IsBorrowable = entry.IsBorrowable;
            CategoryId = entry.CategoryId;
        }
    }
}
