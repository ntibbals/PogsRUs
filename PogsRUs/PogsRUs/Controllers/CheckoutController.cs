using Microsoft.AspNetCore.Mvc;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly ICheckout _context;

        public CheckoutController(ICheckout context)
        {
            _context = context;
        }

        public async Task<IActionResult> Receipt(string userID)
        {
            var cart = await _context.CreateReceipt(userID);

            return View(cart);
        }

    }
}
