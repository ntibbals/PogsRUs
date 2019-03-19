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

        /// <summary>
        /// Interface Constructor
        /// </summary>
        /// <param name="context">Cart Context</param>
        public CartController(ICart context)
        {
            _context = context;
        }

        /// <summary>
        /// This is the home page method for viewing a users cart
        /// </summary>
        /// <param name="userID">Users ID</param>
        /// <returns> Cart Home page with all items in cart</returns>
        public async Task<IActionResult> Index(string userID)
        {
            Cart cart = await _context.GetCart(userID);

            return View(cart.CartProducts);
        }

        /// <summary>
        /// This method handles the checkout view
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>Checkout page</returns>
        public async Task<IActionResult> Checkout(string userID)
        {
            Cart cart = await _context.GetCart(userID);          
            
            return View(cart);
        }

        /// <summary>
        /// This method adds a cartproduct into a users cart
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="productID">Product ID</param>
        /// <returns> Takes user to product index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCartProduct(string userID, int productID)
        {
            await _context.AddProduct(productID, userID);

            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

        /// <summary>
        /// This method removes a product entirely from a users cart
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="productID">Product ID</param>
        /// <returns>Home Page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCartProduct(string userID, int productID)
        {
            await _context.DeleteProduct(userID, productID);
            Cart cart = await _context.GetCart(userID);

            return RedirectToAction(actionName: "Index1", controllerName: "Home");

        }

        /// <summary>
        /// This method updates the quantity of a product located in a users cart
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="productID">Product ID</param>
        /// <param name="quantity">New quantity</param>
        /// <returns>Home Page View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCartProductQuantity(string userID, int productID, int quantity)
        {
            await _context.UpdateProductQuantity(productID, userID, quantity);

            return RedirectToAction(actionName: "Index1", controllerName: "Home");
        }

        /// <summary>
        /// This method deletes the cart entirely
        /// </summary>
        /// <param name="userID">User ID </param>
        /// <returns>Home Page View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCart(string userID)
        {
            await _context.DeleteCart(userID);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
