using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PogsRUs.Models;
using PogsRUs.Models.Interfaces;
using PogsRUs.Models.Services;

namespace PogsRUs.Pages.Profile
{
    public class UserProfileModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;

        private readonly ICheckout _context;


        [BindProperty]
        public ApplicationUser User { get; set; }

        [BindProperty]
        public ICollection<Order> Orders { get; set; }

        [FromRoute]
        public string ID { get; set; }

        public UserProfileModel(UserManager<ApplicationUser> userManager, ICheckout context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var User = await _userManager.FindByEmailAsync(ID);
            var Orders = await _context.GetLastTenOrders(5);
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.FindByEmailAsync(ID);

            var email = _userManager.GetClaimsAsync(user);
            
            user.FirstName = User.FirstName;
            user.LastName = User.LastName;

            Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
            await _userManager.AddClaimAsync(user, fullNameClaim);

            await _userManager.UpdateAsync(user);

            return RedirectToPage("/Profile/UserProfile", new { id =user.Email});
        }
    }
}