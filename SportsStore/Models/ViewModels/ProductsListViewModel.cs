using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo Paginglnfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
