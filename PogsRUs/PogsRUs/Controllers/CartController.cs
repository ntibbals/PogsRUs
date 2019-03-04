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
            Cart cart = await _context.GetCart(userID);

            return View(cart.CartProducts);
        }

        public async Task<IActionResult> Checkout(string userID)
        {
            Cart cart = await _context.GetCart(userID);          
            
            return View(cart);
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
            Cart cart = await _context.GetCart(userID);

            return RedirectToAction(actionName: "Index1", controllerName: "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCartProductQuantity(string userID, int productID)
        {
            await _context.AddProduct(productID, userID);

            return RedirectToAction(actionName: "Index1", controllerName: "Home");
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
