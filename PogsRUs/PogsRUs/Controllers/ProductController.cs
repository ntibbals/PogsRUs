using Microsoft.AspNetCore.Mvc;
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


    }
}
