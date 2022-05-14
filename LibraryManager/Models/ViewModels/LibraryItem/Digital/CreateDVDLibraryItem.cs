namespace LibraryManager.Models.ViewModels.LibraryItem.Digital
{
    public class CreateDVDLibraryItem : CreateLibraryItem
    {
        protected override string Type
        {
            get
            {
                return "DVD";
            }
        }
    }
}
