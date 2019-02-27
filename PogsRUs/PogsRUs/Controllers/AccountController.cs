using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        /// <summary>
        /// Method to register a user for the site
        /// </summary>
        /// <param name="regViewM">register view model</param>
        /// <returns>Index view once user is regisered</returns>
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
                    Email = regViewM.Email,
                    Professional = regViewM.Professional

                };

                var result = await _userManager.CreateAsync(user, regViewM.Password);
                if (result.Succeeded)
                {
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim professionalClaim = new Claim("Professional", user.Professional);

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, professionalClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index1", "Home");
                }
            }

            return View(regViewM);
        }

        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// Method to log user into site
        /// </summary>
        /// <param name="loginVM">Login View Model</param>
        /// <returns>View of Home Page</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index1", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(loginVM);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {
            if(error != null)
            {
                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {

            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }
    }
}