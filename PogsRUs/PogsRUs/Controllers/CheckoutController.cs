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


        public CheckoutController(ICheckout context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Summary(string userID)
        {
            var cart = await _context.CreateReceipt(userID);           

            return View(cart);
        }

        public async Task<IActionResult> PaymentInfo(string userID)
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakePayment([Bind("UserID,FirstName,LastName,Address,City,Zipcode,CreditCardNumber,ExpirationDate")]Payment payment)
        {
            if (ModelState.IsValid)
            {
                var cart = await _context.CreateReceipt(payment.UserID);

                //var ourUser = await _userManager.FindByEmailAsync(userID);
                //string id = ourUser.Id;
                StringBuilder stringBuilder = new StringBuilder();
                //string userName = $"{ourUser.FirstName} {ourUser.LastName}";
                stringBuilder.Append($"<p>Thank you for your order! Your total order amount was: {cart.TotalPrice}.");
                stringBuilder.AppendLine("</p>");

                await _emailSender.SendEmailAsync(payment.UserID, "", stringBuilder.ToString());

                return RedirectToAction(nameof(Receipt(payment.UserID)));
            }
            return RedirectToAction(nameof(PaymentInfo(payment.UserID)));
        }

        public async Task<IActionResult> Receipt(string userID)
        {           
            await _context.AddTransactionHistoryProducts(userID);
            return View();
        }

    }
}
