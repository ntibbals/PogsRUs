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
        private readonly PogsRUsDbContext _context;

        public CheckoutManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }

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

        public async Task<Cart> CreateReceipt(string userID)
        {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userID);
            cart.CartProducts = _context.CartProducts.Where(cp => cp.CartID == cart.ID).ToList();
            cart.TotalPrice = await GetTotalCartPrice(cart.CartProducts);
            return cart;
        }

        public async Task<TransactionHistory> CreateTransactionHistory(string userID)
        {
            TransactionHistory transactionHistory = new TransactionHistory(userID);
            _context.TransactionHistories.Add(transactionHistory);
            await _context.SaveChangesAsync();
            return transactionHistory;
        }

        public async Task DeleteTransactionHistoryProduct(string userID, int productID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            TransactionHistoryProduct transactionHistoryProduct = _context.TransactionHistoryProducts.FirstOrDefault(thp => thp.TransactionHistoryID == transactionHistory.ID && thp.ProductID == product.ID);
            _context.TransactionHistoryProducts.Remove(transactionHistoryProduct);
            await _context.SaveChangesAsync();
        }

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

        public async Task<decimal> GetTotalPrice(ICollection<TransactionHistoryProduct> transactionHistoryProducts)
        {
            decimal totalPrice = 0;

            foreach (TransactionHistoryProduct transactionHistoryProduct in transactionHistoryProducts)
            {
                totalPrice = totalPrice + transactionHistoryProduct.TotalPrice;
            }

            return totalPrice;
        }

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

        public async Task<ICollection<TransactionHistoryProduct>> GetTransactionHistoryProducts(string userID)
        {
            TransactionHistory transactionHistory = await GetTransactionHistory(userID);

            var allProductsInTransactionHistory = _context.TransactionHistoryProducts.Where(thp => thp.TransactionHistoryID == transactionHistory.ID);

            return allProductsInTransactionHistory.ToList();
        }

        public async Task<decimal> GetTotalCartPrice(ICollection<CartProduct> cartProducts)
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
