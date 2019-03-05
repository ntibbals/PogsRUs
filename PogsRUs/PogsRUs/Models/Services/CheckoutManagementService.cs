using Microsoft.EntityFrameworkCore;
using PogsRUs.Data;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Services
{
    public class CheckoutManagementService : ICheckout
    {
        //Injecting DB
        private readonly PogsRUsDbContext _context;

        /// <summary>
        /// This is the Checkout Management service constructor
        /// </summary>
        /// <param name="context">Pogs DB</param>
        public CheckoutManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method adds given transaction history products to table
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns></returns>
        public async Task AddTransactionHistoryProducts(string userID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            if (transactionHistory == null)
            {
                transactionHistory = await CreateTransactionHistory(userID);
            }

            Cart cart = await CreateReceipt(userID);
 
            DateTime currentTime = DateTime.Today;

            foreach (CartProduct cartProduct in cart.CartProducts)
            {
                TransactionHistoryProduct newTransactionHistoryProduct = new TransactionHistoryProduct(cartProduct.ProductID, transactionHistory.ID, cartProduct.Name, cartProduct.SingleItemPrice, cartProduct.Quantity, currentTime);
                _context.Add(newTransactionHistoryProduct);
                _context.Remove(cartProduct);
            }
            _context.Remove(cart);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method creates a receipt for the user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>cart</returns>
        public async Task<Cart> CreateReceipt(string userID)
        {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userID);
            cart.CartProducts = _context.CartProducts.Where(cp => cp.CartID == cart.ID).ToList();
            cart.TotalPrice = await GetTotalCartPrice(cart.CartProducts);
            return cart;
        }

        /// <summary>
        /// This method creates the transtion history for table
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public async Task<TransactionHistory> CreateTransactionHistory(string userID)
        {
            TransactionHistory transactionHistory = new TransactionHistory(userID);
            _context.TransactionHistories.Add(transactionHistory);
            await _context.SaveChangesAsync();
            return transactionHistory;
        }

        /// <summary>
        /// This method deletes a transaction history product from table
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="productID">product id</param>
        /// <returns></returns>
        public async Task DeleteTransactionHistoryProduct(string userID, int productID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            TransactionHistoryProduct transactionHistoryProduct = _context.TransactionHistoryProducts.FirstOrDefault(thp => thp.TransactionHistoryID == transactionHistory.ID && thp.ProductID == product.ID);
            _context.TransactionHistoryProducts.Remove(transactionHistoryProduct);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method deletes the transaction history from table
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns></returns>
        public async Task DeletTransactionHistory(string userID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            var allProductsInTransactionHistory = _context.TransactionHistoryProducts.Where(thp => thp.TransactionHistoryID == transactionHistory.ID);

            foreach (TransactionHistoryProduct transactionHistoryProduct in allProductsInTransactionHistory)
            {
                _context.TransactionHistoryProducts.Remove(transactionHistoryProduct);
            }
            _context.Remove(transactionHistory);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method gets the total price of transaction history products
        /// </summary>
        /// <param name="transactionHistoryProducts">transaction history products</param>
        /// <returns>total price</returns>
        public async Task<decimal> GetTotalPrice(IEnumerable<TransactionHistoryProduct> transactionHistoryProducts)
        {
            decimal totalPrice = 0;

            foreach (TransactionHistoryProduct transactionHistoryProduct in transactionHistoryProducts)
            {
                totalPrice = totalPrice + transactionHistoryProduct.TotalPrice;
            }

            return totalPrice;
        }

        /// <summary>
        /// This method gets the transaction history from table
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>transaction history data</returns>
        public async Task<TransactionHistory> GetTransactionHistory(string userID)
        {
            TransactionHistory transactionHistory = await _context.TransactionHistories.FirstOrDefaultAsync(p => p.UserID == userID);

            transactionHistory.PurchasedProducts = await GetTransactionHistoryProducts(userID);

            transactionHistory.TotalPrice = await GetTotalPrice(transactionHistory.PurchasedProducts);

            if (transactionHistory == null)
            {
                return null;
            }
            return transactionHistory;
        }

        /// <summary>
        /// This method gets the transaction history products from table
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>transaction history products</returns>
        public async Task<IEnumerable<TransactionHistoryProduct>> GetTransactionHistoryProducts(string userID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            var allProductsInTransactionHistory = _context.TransactionHistoryProducts.Where(thp => thp.TransactionHistoryID == transactionHistory.ID);

            return allProductsInTransactionHistory;
        }

        /// <summary>
        /// This method gets the total price of the cart
        /// </summary>
        /// <param name="cartProducts">cart products in given cart</param>
        /// <returns>total price</returns>
        public async Task<decimal> GetTotalCartPrice(IEnumerable<CartProduct> cartProducts)
        {
            decimal totalPrice = 0;

            foreach (CartProduct cartProduct in cartProducts)
            {
                totalPrice = totalPrice + cartProduct.TotalPrice;
            }

            return totalPrice;
        }
    }
}
