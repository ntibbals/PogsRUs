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
    public class ProductController : Controller
    {
        private readonly IInventory _context;

        public ProductController(IInventory context)
        {
            _context = context;
        }

        /// Get Products
        public async Task<IActionResult> Index(string searchString)
        {
            var product = await _context.GetProducts();
            if(!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.Contains(searchString));
            }

            return View(product.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Sku, Name, PogType, Price, Description, Image")] Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _context.CreateProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception)
            {
                return Redirect("https://http.cat/500");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.GetProduct(id);

            return View(product);
        }

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
                    await _context.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

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
