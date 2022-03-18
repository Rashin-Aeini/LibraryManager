using System.Collections.Generic;

namespace LibraryManager.Models.ViewModels
{
    public class Pagination<T> where T : class
    {
        public Pagination()
        {
            Records = new List<T>();
        }

        public List<T> Records { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
