using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTechBusiness.Abstract;
using MyTechWebUı.Identity;
using MyTechWebUı.Models.CartModels;
using Org.BouncyCastle.Bcpg;

namespace MyTechWebUı.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService,UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var CartItem = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(x => new CartItemModel()
                {
                    CartItemId= x.Id,
                    ProductId= x.ProductId,
                    Name=x.Product.ProductName,
                    Price=x.Product.ProductPrice,
                    ImgUrl=x.Product.ImgUrl1,
                    Quantity=x.Quantity
                }).ToList(),
            };
            return View(CartItem);
        }
        [HttpPost]
        public IActionResult AddToCart(int productId,int quantity)
        {
            var userId=_userManager.GetUserId(User);
            _cartService.AddTooCart(userId,productId,quantity);
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index");
        }
    }
}
