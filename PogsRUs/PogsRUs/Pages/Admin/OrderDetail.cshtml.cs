using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;

namespace PogsRUs.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrderDetailModel : PageModel
    {
        private readonly ICheckout _checkout;
        [BindProperty]
        public Order Order { get; set; }

        [FromRoute]
        public int? ID { get; set; }

        public OrderDetailModel(ICheckout checkout)
        {
            _checkout = checkout;
        }

        /// <summary>
        /// Get Order based on order id
        /// </summary>
        /// <returns>order</returns>
        public async Task OnGetAsync()
        {
            Order = await _checkout.GetOrderByOrderID(ID.GetValueOrDefault());
        }
    }
}