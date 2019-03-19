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
        Task<Order> CreateOrder(string userID, string custName);


        /// <summary>
        /// Retreives Transaction History that matches user ID
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Users TransactionHistory</returns>
        Task<Order> GetOrder(string userID);

        /// <summary>
        /// Adds all cartProducts to TransactionHistoryProduct
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task AddOrderProducts(string userID, string custName);

        /// <summary>
        /// Retreive all existing products in TransactionHistoryProduct and returns as a list.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns></returns>
        Task<ICollection<OrderProduct>> GetOrderProducts(int orderID);

        /// <summary>
        /// Deletes existing product from TransactionHistoryProduct.
        /// </summary>
        /// <param name="productID">ID of Product</param>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeleteOrderProduct(string userID, int productID);

        /// <summary>
        /// Deletes TransactionHistory.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Task</returns>
        Task DeleteOrder(string userID);

        /// <summary>
        /// Receives a collection of TransactionHistoryProduct and returns a Total Price for all items in the TransactionHistory.
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Returns a decimal value indicating Total Price of all items in TransactionHistory</returns>
        Task<decimal> GetTotalPrice(ICollection<OrderProduct> transactionHistoryProducts);

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

        /// <summary>
        /// Creates an order history for user.
        /// </summary>
        /// <param name="userID">ID of user</param>
        /// <returns>Adds Order History to DB</returns>
        Task<OrderHistory> CreateOrderHistory(string userID);

        /// <summary>
        /// Retreives a users Order History
        /// </summary>
        /// <param name="userID">ID of User</param>
        /// <returns>Returns User's Order History</returns>
        Task<OrderHistory> GetOrderHistory(string userID);

        /// <summary>
        /// Retrieves All Orders
        /// </summary>
        /// <returns>Returns an ICollection of All Orders in DB</returns>
        Task<ICollection<Order>> GetAllOrders();

        /// <summary>
        /// Retrieves All Users Orders
        /// </summary>
        /// <returns>Returns an ICollection of All User Orders in DB</returns>
        Task<ICollection<Order>> GetAllUserOrders(string userID);

        /// <summary>
        /// Retreive the last ten orders for admin page
        /// </summary>
        /// <param name="number">number of orders to retreive</param>
        /// <returns>List of ten orders</returns>
        Task<ICollection<Order>> GetLastTenOrders(int number);

        /// <summary>
        /// Get an order specifically based on order ID
        /// </summary>
        /// <param name="ID">order ID</param>
        /// <returns>individual order</returns>
        Task<Order> GetOrderByOrderID(int ID);
    }
}
