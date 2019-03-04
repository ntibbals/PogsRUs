using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Interfaces
{
    public interface ICart
    {

        /// <summary>
        /// Create Cart
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task<Cart> CreateCart(string userID);


        /// <summary>
        /// Retreives Cart that matches user ID
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Users cart</returns>
        Task<Cart>GetCart(string userID);

        /// <summary>
        /// Adds product and increased quanitiy of product by one
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task AddProduct(int productID, string userID);

        /// <summary>
        /// Retreive all existing products in cart and returns as a list.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task<ICollection<CartProduct>> GetCartProducts(Cart cart);

        /// <summary>
        /// Deletes existing product from Cart.
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeleteProduct(string userID, int productID);

        /// <summary>
        /// Deletes Cart.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeleteCart(string userID);

        /// <summary>
        /// Receives a collection of cart products and returns a Total Price for all items in the cart.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Returns a decimal value indicating Total Price of all items in cart</returns>
        Task<decimal> GetTotalPrice(ICollection<CartProduct> cartProducts);
    }
}
