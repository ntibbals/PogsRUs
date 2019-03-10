using Microsoft.EntityFrameworkCore;
using PogsRUs.Data;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Services
{
    public class InventoryManagementService : IInventory
    {
        //Injecting DB
        private readonly PogsRUsDbContext _context;

        public InventoryManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Deletes existing product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Searches all products and returns product that matches input id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product product</returns>
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
        }

        /// <summary>
        /// Retreive all existing product and returns as a list.
        /// </summary>
        /// <returns>List of Products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Either creates or updates a product.
        /// </summary>
        /// <param name="product">Incoming product</param>
        /// <returns>Either adds new product to db or updates exisiting product</returns>
        public async Task SaveAsync(Product product)
        {
            //If existing post isnt found then post is added.
            if (await _context.Products.FirstOrDefaultAsync(p => p.ID == product.ID) == null)
            {
                _context.Products.Add(product);
            }
            //If existing post is found then post is updated
            else
            {
                _context.Products.Update(product);
            }
            await _context.SaveChangesAsync();
        }
    }
}
