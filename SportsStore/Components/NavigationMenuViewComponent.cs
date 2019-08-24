using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Models.Interface;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["Category"];
            return View(repository.Products
                                  .Select(x => x.Category)
                                  .Distinct()
                                  .OrderBy(x => x));
        }
    }
}
