using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PogsRUs.Models;

namespace PogsRUs.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IAsyncResult> Register(RegisterViewModel regViewM)
        {
            if (ModelState.IsValid)
            {
                //ToDo: Application new user here
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = regViewM.FirstName,
                    LastName = regViewM.LastName,
                    Birthday = regViewM.Birthday,
                    UserName = regViewM.Email,
                    Email = regViewM.Email

                };


                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(_userManager, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return regViewM(regViewM);
        }
    }
}