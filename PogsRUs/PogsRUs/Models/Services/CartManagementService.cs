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


        public async Task AddProduct(int productID, string userID)
        {
            Cart cart = await GetCart(userID);
            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            if(cart == null)
            {
                cart = await CreateCart(userID);
            }

            CartProduct cartProduct = await _context.CartProducts.FirstOrDefaultAsync(cp => cp.CartID == cart.ID && cp.ProductID == product.ID);
            if (cartProduct == null)
            {
                CartProduct newCartProduct = new CartProduct(product.ID, cart.ID, product.Name, product.Price);
                
                _context.Add(newCartProduct);
            }
            else
            {
                cartProduct.Quantity = cartProduct.Quantity + 1;
                _context.Update(cartProduct);
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductQuantity(int productID, string userID, int quantity)
        {
            Cart cart = await GetCart(userID);
            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            if (cart == null)
            {
                cart = await CreateCart(userID);
            }

            CartProduct cartProduct = await _context.CartProducts.FirstOrDefaultAsync(cp => cp.CartID == cart.ID && cp.ProductID == product.ID);
            if (cartProduct == null)
            {
                CartProduct newCartProduct = new CartProduct(product.ID, cart.ID, product.Name, product.Price);

                _context.Add(newCartProduct);
            }
            else
            {
                cartProduct.Quantity = quantity;
                _context.Update(cartProduct);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Cart> CreateCart(string userID)
        {
            Cart cart = new Cart(userID);
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
      

        public async Task DeleteCart(string userID)
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

        public async Task DeleteProduct(string userID, int productID)
        {
            Cart cart = await GetCart(userID);
            Product product = _context.Products.FirstOrDefault(p => p.ID == productID);

            CartProduct cartProduct = _context.CartProducts.FirstOrDefault(cp => cp.CartID == cart.ID && cp.ProductID == product.ID);
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(string userID)
        {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(p => p.UserID == userID);
            if (cart != null)
            {
                cart.CartProducts = await GetCartProducts(cart);

                cart.TotalPrice = await GetTotalPrice(cart.CartProducts);
            }
                    
            return cart;
        }

        public async Task<ICollection<CartProduct>> GetCartProducts(Cart cart)
        {
            
            var allProductsInCart = await _context.CartProducts.Where(cp => cp.CartID == cart.ID).ToListAsync();
            
            return allProductsInCart;
        }

        public async Task<decimal> GetTotalPrice(ICollection<CartProduct> cartProducts)
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
