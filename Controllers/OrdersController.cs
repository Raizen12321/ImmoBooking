using ImmoBooking.Data.Cart;
using ImmoBooking.Data.Services;
using ImmoBooking.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImmoBooking.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IPropertiesService _propertiesService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IPropertiesService propertiesService, ShoppingCart shoppingCart)
        {
            _propertiesService = propertiesService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart= _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _propertiesService.GetPropertyByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemtoCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _propertiesService.GetPropertyByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

    }
}
