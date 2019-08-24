using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SportsStore.Models;
using SportsStore.Models.Interface;
using System.Linq;


namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository repository;       
        public AdminController(IProductRepository rep)
        {
            repository = rep;
            
        }
        public IActionResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) =>
             View(repository.Products
                            .FirstOrDefault(p => p.ID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);

            if (deleteProduct != null)
            {
                TempData["message"] = $"{deleteProduct.Name} was deleted";
                ViewData["product"] = deleteProduct;
            }
            return RedirectToAction(nameof(Index));
        }      

        
    }
}
