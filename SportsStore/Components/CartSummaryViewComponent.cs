using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Carts;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
