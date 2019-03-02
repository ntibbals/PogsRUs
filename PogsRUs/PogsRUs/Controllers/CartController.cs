using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Controllers
{
    public class CartController : Controller
    {

        private readonly ICart _context;

        public CartController(ICart context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string userID)
        {
            var cartProducts = await _context.GetCartProducts(userID);
            
            return View(cartProducts.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCartProduct(string userID, int productID)
        {
            await _context.AddProduct(productID, userID);

            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCartProduct(string userID, int productID)
        {
            await _context.DeleteProduct(userID, productID);

            return RedirectToAction(actionName: "Index", controllerName: "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCartProductQuantity(string userID, int productID)
        {
            await _context.AddProduct(productID, userID);

            return RedirectToAction(actionName: "Index", controllerName: "Cart");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCart(string userID)
        {
            await _context.DeleteCart(userID);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
