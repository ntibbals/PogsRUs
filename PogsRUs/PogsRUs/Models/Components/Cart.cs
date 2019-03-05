using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PogsRUs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PogsRUs.Models.Services;

namespace PogsRUs.Models.Components
{
    public class Cart : ViewComponent
    {
        //Injecting DB
        private readonly PogsRUsDbContext _context;

        /// <summary>
        /// Cart constructor
        /// </summary>
        /// <param name="context">PogsRUS DB Context</param>
        public Cart(PogsRUsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method displays given View Components asyncronously
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <returns>View Component</returns>
        public async Task<IViewComponentResult> InvokeAsync(string userID)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(p => p.UserID == userID);

            if(cart != null)
            {
                var cartProducts = _context.CartProducts.Where(cp => cp.CartID == cart.ID).ToList();
                if(cartProducts.Count > 0)
                {
                    return View(cartProducts);
                }
                return View(null);
            }

            return View(null);
        }
    }
}
