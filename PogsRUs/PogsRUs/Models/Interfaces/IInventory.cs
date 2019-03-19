using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Interfaces
{
    public interface IInventory
    {
        
        /// <summary>
        /// Searches all products and returns product that matches input id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product product</returns>
        Task<Product> GetProduct(int id);

        /// <summary>
        /// Retreive all existing product and returns as a list.
        /// </summary>
        /// <returns>List of Products</returns>
        Task<IEnumerable<Product>> GetProducts();
     

        /// <summary>
        /// Deletes existing product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task DeleteProduct(Product product);

        /// <summary>
        /// Either creates or updates a product.
        /// </summary>
        /// <param name="product">Incoming product</param>
        /// <returns>Either adds new product to db or updates exisiting product</returns>
        Task SaveAsync(Product product);
    }
}
