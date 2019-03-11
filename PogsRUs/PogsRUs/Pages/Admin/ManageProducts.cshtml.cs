using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;

namespace PogsRUs.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class ManageProductsModel : PageModel
    {
        private readonly IInventory _context;

        public ManageProductsModel(IInventory context)
        {
            _context = context;
        }

        /// <summary>
        /// Holding spot for Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Sets Products from DB /// </summary>
        /// <returns></returns>
        
        public async Task<IEnumerable<Product>> OnGet()
        {
            
            Products = await _context.GetProducts();
            return Products;
        }
    }
} 

