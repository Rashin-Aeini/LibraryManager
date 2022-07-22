namespace LibraryManager.Models.ViewModels.LibraryItem.Physical
{
    public class CreateReferenceLibraryItem : CreateLibraryItem
    {
        protected override string Type
        {
            get
            {
                return "Reference";
            }
        }
    }
}
