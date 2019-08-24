using System;

namespace SportsStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int Totalitems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)Totalitems / ItemsPerPage);
    }
}
