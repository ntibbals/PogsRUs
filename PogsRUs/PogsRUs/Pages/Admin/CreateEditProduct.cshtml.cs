using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;


namespace PogsRUs.Pages.Admin
{
    public class CreateEditProductModel : PageModel
    {
        private readonly IInventory _context;

        public CreateEditProductModel(IInventory context)
        {
            _context = context;

        }

        // <summary>
        /// Sets the ID
        /// </summary>
        [FromRoute]
        public int? ID { get; set; }

        /// <summary>
        /// Holding Spot for Product
        /// </summary>
        [BindProperty]
        public Product Product { get; set; }

        /// <summary>
        /// Sets the Product
        /// </summary>
        /// <returns>Post</returns>
        public async Task OnGet()
        {
            Product = await _context.GetProduct(ID.GetValueOrDefault()) ?? new Product();
        }

        /// <summary>
        /// Saves updated or new Product into database and redirects to ManageProducts Page.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            var product = await _context.GetProduct(ID.GetValueOrDefault()) ?? new Product();

            product.Sku = Product.Sku;
            product.Name = Product.Name;
            product.PogType = Product.PogType;
            product.Price = Product.Price;
            product.Description = Product.Description;
            product.Image = Product.Image;
            
            await _context.SaveAsync(product);

            return RedirectToPage("ManageProducts");
        }

        /// <summary>
        /// Deletes post from database and redirects to ManageProducts Page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete()
        {
            var product = await _context.GetProduct(ID.GetValueOrDefault()) ?? new Product();
            await _context.DeleteProduct(product);
            return RedirectToPage("ManageProducts");
        }

    }
}