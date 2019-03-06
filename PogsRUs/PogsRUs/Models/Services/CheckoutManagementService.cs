﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddOrderProducts(string userID)
        {
            Order order = await GetOrder(userID);

            if (order == null)
            {
                order = await CreateOrder(userID);
            }

            OrderHistory orderHistory = await GetOrderHistory(userID);

            if(orderHistory == null)
            {
                orderHistory = await CreateOrderHistory(userID);
            }

            Cart cart = await CreateReceipt(userID);
 
            DateTime currentTime = DateTime.Today;

            foreach (CartProduct cartProduct in cart.CartProducts)
            {
                OrderProduct newOrderProduct = new OrderProduct(cartProduct.ProductID, order.ID, cartProduct.Name, cartProduct.SingleItemPrice, cartProduct.Quantity, currentTime);
                _context.Add(newOrderProduct);
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

        public async Task<Order> CreateOrder(string userID)
        {
            DateTime currentTime = DateTime.Today;
            Order order = new Order(userID, currentTime);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderProduct(string userID, int productID)
        {
            Order order = await GetOrder(userID);

            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            OrderProduct orderProduct = _context.OrderProducts.FirstOrDefault(thp => thp.OrderID == order.ID && thp.ProductID == product.ID);
            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(string userID)
        {
            Order order = await GetOrder(userID);

            var allProductsInOrder = _context.OrderProducts.Where(op => op.OrderID == order.ID);

            foreach (OrderProduct orderProduct in allProductsInOrder)
            {
                _context.OrderProducts.Remove(orderProduct);
            }
            _context.Remove(order);

            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalPrice(ICollection<OrderProduct> orderProducts)
        {
            decimal totalPrice = 0;

            foreach (OrderProduct orderProduct in orderProducts)
            {
                totalPrice = totalPrice + orderProduct.TotalPrice;
            }

            return totalPrice;
        }

        public async Task<Order> GetOrder(string userID)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(p => p.UserID == userID);

            order.PurchasedProducts = await GetOrderProducts(userID);

            order.TotalPrice = await GetTotalPrice(order.PurchasedProducts);

            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<ICollection<OrderProduct>> GetOrderProducts(string userID)
        {
            Order order = await GetOrder(userID);

            var allProductsInOrder = _context.OrderProducts.Where(thp => thp.OrderID == order.ID);

            return allProductsInOrder.ToList();
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

        public async Task<OrderHistory> CreateOrderHistory(string userID)
        {
            OrderHistory orderHistory = new OrderHistory(userID);
            _context.OrderHistories.Add(orderHistory);
            await _context.SaveChangesAsync();
            return orderHistory;
        }

        public async Task<OrderHistory> GetOrderHistory(string userID)
        {
            OrderHistory orderHistory = await _context.OrderHistories.FirstOrDefaultAsync(oh => oh.UserID == userID);

            if (orderHistory == null)
            {
                orderHistory = await CreateOrderHistory(userID);
            }

            orderHistory.AllUserOrders = await GetAllUserOrders(userID);

            
            return orderHistory;
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<ICollection<Order>> GetAllUserOrders(string userID)
        {
            OrderHistory orderHistory = await GetOrderHistory(userID);

            if (orderHistory == null)
            {
                orderHistory = await CreateOrderHistory(userID);
            }

            var allUsersOrders = _context.Orders.Where(o => o.UserID == orderHistory.UserID);

            return allUsersOrders.ToList();
        }
    }
}
