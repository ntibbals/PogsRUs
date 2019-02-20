using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PogsRUs.Models;
using PogsRUs.Models.ViewModels;

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
        public async Task<IActionResult> Register(RegisterViewModel regViewM)
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

                var result = await _userManager.CreateAsync(user, regViewM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(regViewM);
        }
    }
}