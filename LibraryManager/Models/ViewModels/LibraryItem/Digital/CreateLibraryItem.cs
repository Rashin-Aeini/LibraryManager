namespace LibraryManager.Models.ViewModels.LibraryItem.Digital
{
    public abstract class CreateLibraryItem : BaseLibraryItem
    {
        public int RunTimeMinutes { get; set; }
        protected abstract string Type { get; }

        public override Domains.LibraryItem MapGetter()
        {
            return new Domains.LibraryItem()
            {
                Title = Title,
                Type = Type,
                RunTimeMinutes = RunTimeMinutes,
                IsBorrowable = IsBorrowable,
                CategoryId = CategoryId
            };
        }

        public override void MapSetter(Domains.LibraryItem entry)
        {
        }
    }
}
