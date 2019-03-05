using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Interfaces
{
    public interface ICheckout
    {

        /// <summary>
        /// Creates Transaction History for user.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>New Transaction History</returns>
        Task<TransactionHistory> CreateTransactionHistory(string userID);


        /// <summary>
        /// Retreives Transaction History that matches user ID
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Users TransactionHistory</returns>
        Task<TransactionHistory> GetTransactionHistory(string userID);

        /// <summary>
        /// Adds all cartProducts to TransactionHistoryProduct
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task AddTransactionHistoryProducts(string userID);

        /// <summary>
        /// Retreive all existing products in TransactionHistoryProduct and returns as a list.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task<ICollection<TransactionHistoryProduct>> GetTransactionHistoryProducts(string userID);

        /// <summary>
        /// Deletes existing product from TransactionHistoryProduct.
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeleteTransactionHistoryProduct(string userID, int productID);

        /// <summary>
        /// Deletes TransactionHistory.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeletTransactionHistory(string userID);

        /// <summary>
        /// Receives a collection of TransactionHistoryProduct and returns a Total Price for all items in the TransactionHistory.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Returns a decimal value indicating Total Price of all items in TransactionHistory</returns>
        Task<decimal> GetTotalPrice(ICollection<TransactionHistoryProduct> transactionHistoryProducts);

        /// <summary>
        /// Collects all cartProducts that are associated with user id and returns them as a list.
        /// </summary>
        /// <param name="userID">User of logged in user</param>
        /// <returns>List of cart products</returns>
        Task<Cart> CreateReceipt(string userID);

        /// <summary>
        /// Finds the sum of all products in cart and returns sum
        /// </summary>
        /// <param name="cartProducts">List of cart products in cart</param>
        /// <returns>Total Price of Items cart</returns>
        Task<decimal> GetTotalCartPrice(ICollection<CartProduct> cartProducts);

    }
}
