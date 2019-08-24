using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Carts;
using SportsStore.Models.Interface;
using SportsStore.Models.ViewModels;
using System.Linq;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository Repository;
        private readonly Cart Cart;
        public CartController(IProductRepository repository, Cart cartService)
        {
            Repository = repository;
            Cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = Cart, ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCart(int ID, string returnUrl)
        {
            Product product = Repository.Products
                                        .FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = Repository.Products
                                        .FirstOrDefault(p => p.ID == productID);
            if (product != null)
            {
                Cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
