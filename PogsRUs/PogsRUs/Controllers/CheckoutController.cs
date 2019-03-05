using AuthorizeNet.Api.Contracts.V1;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;
using PogsRUs.Models.ViewModels;
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
        private Payment Payment;
        IConfiguration _configuration;

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

            return View(cart);
        }

        public async Task<IActionResult> PaymentInfo(string userID)
        {
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakePayment([Bind("UserID,FirstName,LastName,Address,City,Zipcode,CreditCardNumber,ExpirationDate")]PaymentViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                var cart = await _context.CreateReceipt(pvm.UserID);

                var userCard = new creditCardType
                {
                    cardNumber = pvm.CreditCardNumber,
                    expirationDate = pvm.ExpirationDate
                };

                var billingAddress = new customerAddressType
                {
                    firstName = pvm.FirstName,
                    lastName = pvm.LastName,
                    address = pvm.Address,
                    city = pvm.City,
                    zip = pvm.Zipcode
                };
                

                decimal amount = cart.TotalPrice;
                Payment payment = new Payment(_configuration);
                payment.Run(userCard, pvm.UserID, billingAddress, amount);
                //var ourUser = await _userManager.FindByEmailAsync(userID);
                //string id = ourUser.Id;
                StringBuilder stringBuilder = new StringBuilder();
                //string userName = $"{ourUser.FirstName} {ourUser.LastName}";
                stringBuilder.Append($"<p>Thank you for your order! Your total order amount was: {cart.TotalPrice}.");
                stringBuilder.AppendLine("</p>");

                await _emailSender.SendEmailAsync(pvm.UserID, "", stringBuilder.ToString());

                return RedirectToAction(nameof(Receipt), pvm.UserID);
            }
            return RedirectToAction(nameof(PaymentInfo), pvm.UserID);
        }

        public async Task<IActionResult> Receipt(string userID)
        {           
            await _context.AddTransactionHistoryProducts(userID);
            return View();
        }

    }
}
