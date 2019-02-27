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
            CartProduct cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.CartID == cart.ID && cp.ProductID == product.ID);
            if (cartProduct == null)
            {
                cartProduct.CartID = cart.ID;
                cartProduct.ProductID = product.ID;
                cartProduct.Quantity = 1;
                _context.Add(cartProduct);
            }
            else
            {
                cartProduct.Quantity = cartProduct.Quantity + 1;
                _context.Update(cartProduct);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CreateCart(int userID)
        {
            Cart cart = new Cart(userID);
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }
      

        public async Task DeleteCart(int userID)
        {
            Cart cart = await GetCart(userID);

            var allProductsInCart = _context.CartProducts.Where(cp => cp.CartID == cart.ID);

            foreach(CartProduct cartProduct in allProductsInCart)
            {
                _context.CartProducts.Remove(cartProduct);
            }
            _context.Remove(cart);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int userID, Product product)
        {
            Cart cart = await GetCart(userID);
            CartProduct cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.CartID == cart.ID && cp.ProductID == product.ID);
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(int userID)
        {
            return await _context.Carts.FirstOrDefaultAsync(p => p.UserID == userID);
        }

        public async Task<IEnumerable<CartProduct>> GetCartProducts(int userID)
        {
            Cart cart = await GetCart(userID);
            var allProductsInCart = _context.CartProducts.Where(cp => cp.CartID == cart.ID);
            return allProductsInCart;
        }

    }
}
