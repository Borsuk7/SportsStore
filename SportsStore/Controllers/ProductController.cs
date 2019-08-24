using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Interface;
using SportsStore.Models.ViewModels;
using System.Linq;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public int PageSize = 4;

        public ViewResult List(string Category, int ProductPage = 1)
        {
            ViewBag.Title = "Products";

            return View(new ProductsListViewModel
            {
                Products = repository.Products
                                     .Where(p => Category == null || p.Category == Category)
                                     .OrderBy(p => p.ID)
                                     .Skip((ProductPage - 1) * PageSize)
                                     .Take(PageSize),
                Paginglnfo = new PagingInfo
                {
                    CurrentPage = ProductPage,
                    ItemsPerPage = PageSize,
                    Totalitems = Category == null ? repository.Products.Count() : repository.Products
                                                                                            .Where(p => p.Category == Category)
                                                                                            .Count()

                },
                CurrentCategory = Category
            });
        }
    }
}

