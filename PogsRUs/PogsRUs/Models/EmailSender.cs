using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class EmailSender : IEmailSender
    {
        //Injecting DB
        private IConfiguration _configuration;

        /// <summary>
        /// Email Sender Constructor
        /// </summary>
        /// <param name="configuration">configuration injection</param>
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// This method handles all emails being sent
        /// </summary>
        /// <param name="email">type of email</param>
        /// <param name="subject">subject line</param>
        /// <param name="htmlMessage">message of email</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["Sendgrid_Api_Key"]);

            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("admin@pogrus.com", "Pog's R Us Admin");

            msg.AddTo(email);
            msg.SetSubject("Thanks for Choosing Pog's R Us");
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);


        }
    }
}
