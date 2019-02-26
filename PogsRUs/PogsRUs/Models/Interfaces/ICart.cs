using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Interfaces
{
    interface ICart
    {

        /// <summary>
        /// Create Cart
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Task</returns>
        Task CreateCartCreateCart(int userID);


        /// <summary>
        /// Retreives Cart that matches user ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Users cart</returns>
        Task<Cart>GetCart(int userID);

        /// <summary>
        /// Adds product and increased quanitiy of product by one
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product product</returns>
        Task AddProduct(Product product, int userID);

        /// <summary>
        /// Retreive all existing products in cart and returns as a list.
        /// </summary>
        /// <returns>List of Products</returns>
        Task<List<KeyValuePair<Product, int>>> GetProducts(int userID);

        /// <summary>
        /// Deletes existing product from Cart.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task DeleteProduct(int userID, Product product);

        /// <summary>
        /// Deletes Cart.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        Task DeleteCart(int userID);
    }
}
