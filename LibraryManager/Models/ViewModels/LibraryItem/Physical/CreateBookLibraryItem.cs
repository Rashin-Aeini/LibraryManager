namespace LibraryManager.Models.ViewModels.LibraryItem.Physical
{
    public class CreateBookLibraryItem : CreateLibraryItem
    {
        protected override string Type
        {
            get
            {
                return "Book";
            }
        }
    }
}
