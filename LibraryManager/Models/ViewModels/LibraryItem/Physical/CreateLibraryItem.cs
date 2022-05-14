using System;

namespace LibraryManager.Models.ViewModels.LibraryItem.Physical
{
    public abstract class CreateLibraryItem : BaseLibraryItem
    {
        public string Author { get; set; }
        public int Pages { get; set; }
        protected abstract string Type { get; }

        public override Domains.LibraryItem MapGetter()
        {
            return new Domains.LibraryItem()
            {
                Title = Title,
                Type = Type,
                Author = Author,
                Pages = Pages,
                IsBorrowable = IsBorrowable,
                CategoryId = CategoryId
            };
        }

        public override void MapSetter(Domains.LibraryItem entry)
        {
        }
    }
}
