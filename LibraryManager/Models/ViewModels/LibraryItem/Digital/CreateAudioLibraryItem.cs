namespace LibraryManager.Models.ViewModels.LibraryItem.Digital
{
    public class CreateAudioLibraryItem : CreateLibraryItem
    {
        protected override string Type
        {
            get
            {
                return "Audio";
            }
        }
    }
}
