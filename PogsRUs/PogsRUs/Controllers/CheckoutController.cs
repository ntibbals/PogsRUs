using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogsRUs.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly ICheckout _context;
        private IEmailSender _emailSender;
        private UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Interface Constructor
        /// </summary>
        /// <param name="context">checkout context</param>
        /// <param name="userManager">user manager</param>
        /// <param name="emailSender">email sender</param>
        public CheckoutController(ICheckout context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        /// <summary>
        /// This method takes the user to the summary page and currently utilizes Email sender to send a receipt email
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>Cart View to see summary</returns>
        public async Task<IActionResult> Summary(string userID)
        {
            var cart = await _context.CreateReceipt(userID);

            //var ourUser = await _userManager.FindByEmailAsync(userID);
            //string id = ourUser.Id;
            StringBuilder stringBuilder = new StringBuilder();
            //string userName = $"{ourUser.FirstName} {ourUser.LastName}";
            stringBuilder.Append($"<p>Thank you for your order! Your total order amount was: {cart.TotalPrice}.");
            stringBuilder.AppendLine("</p>");

            await _emailSender.SendEmailAsync(userID, "", stringBuilder.ToString());

            return View(cart);
        }

    }
}
