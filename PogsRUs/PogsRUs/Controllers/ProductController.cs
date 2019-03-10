using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PogsRUs.Controllers
{
    public class ProductController : Controller
    {
        private readonly IInventory _context;

        /// <summary>
        /// Product Controller Constructor
        /// </summary>
        /// <param name="context">Inventory context</param>
        public ProductController(IInventory context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Products for index page
        /// </summary>
        /// <param name="searchString">search criteria</param>
        /// <returns>all products</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            var product = await _context.GetProducts();
            if(!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.Contains(searchString));
            }

            return View(product.ToList());
        }

        /// <summary>
        /// Get details for specific product
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>details for specified product</returns>
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }
            
            return View(product);
        }

        /// <summary>
        /// This method is for future use for Creating a product
        /// </summary>
        /// <returns>Create product view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create new product method
        /// </summary>
        /// <param name="product">new product to bind/create</param>
        /// <returns>product view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Sku, Name, PogType, Price, Description, Image")] Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _context.SaveAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");
            }
        }

        /// <summary>
        /// Find product to edit
        /// </summary>
        /// <param name="id">product id to edit</param>
        /// <returns>Edit view</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.GetProduct(id);

            return View(product);
        }

        /// <summary>
        /// Edit method for specified product
        /// </summary>
        /// <param name="id">product id</param>
        /// <param name="product">product object</param>
        /// <returns>Edited product detail view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Sku, Name, PogType, Price, Description, Image")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        /// <summary>
        /// Find product to delete
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product to delete</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Delete product method
        /// </summary>
        /// <param name="id">product to delete</param>
        /// <returns>Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.GetProduct(id);
            await _context.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
