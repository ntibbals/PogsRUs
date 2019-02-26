using Microsoft.EntityFrameworkCore;
using PogsRUs.Data;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Services
{
    public class CartManagementService : ICart
    {

        //Injecting DB
        private readonly PogsRUsDbContext _context;

        public CartManagementService(PogsRUsDbContext context)
        {
            _context = context;
        }


        public async Task AddProduct(Product product, int userID)
        {
            Cart cart = await GetCart(userID);
            if(cart.CartProducts.ContainsKey(product))
            {
                int quantity;
                cart.CartProducts.TryGetValue(product, out quantity);
                quantity = quantity + 1;
                cart.CartProducts[product] = quantity;
            }
            else
            {
                cart.CartProducts.Add(product, 1);
            }
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCart(int userID)
        {
            Cart cart = new Cart(userID);
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public Task CreateCartCreateCart(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCart(int userID)
        {
            Cart cart = await GetCart(userID);
            _context.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int userID, Product product)
        {
            Cart cart = await GetCart(userID);
            cart.CartProducts.Remove(product);
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(int userID)
        {
            return await _context.Carts.FirstOrDefaultAsync(p => p.UserID == userID);
        }

        public async Task<List<KeyValuePair<Product, int>>> GetProducts(int userID)
        {
            Cart cart = await GetCart(userID);
            return cart.CartProducts.ToList();
        }

    }
}
