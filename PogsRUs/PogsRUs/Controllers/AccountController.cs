using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PogsRUs.Models;
using PogsRUs.Models.ViewModels;

namespace PogsRUs.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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
                    Claim userEmailClaim = new Claim("Email", user.Email );

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, professionalClaim, userEmailClaim };


                    await _userManager.AddClaimsAsync(user, claims);

                    StringBuilder stringBuilder = new StringBuilder();
                    string userName = $"{regViewM.FirstName} {regViewM.LastName}";
                    stringBuilder.Append($"<p>Thank you for Registering at Pog's R Us {userName}!");
                    stringBuilder.AppendLine("</p>");

                    await _emailSender.SendEmailAsync(regViewM.Email, "", stringBuilder.ToString());

                    if (user.Email == "jasonhi@crazyredhead.com" || user.Email == "jimmy.f.chang@gmail.com" || user.Email == "amanda@codefellows.com" || user.Email == "ntibbals@outlook.com" )
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }
                        await _signInManager.SignInAsync(user, isPersistent: false);

                    if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    {
                        return LocalRedirect("~/Admin/Dashboard");

                    }

                    return RedirectToAction("Index", "Home");
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
                    var ourUser = await _userManager.FindByEmailAsync(loginVM.Email);
              

                    if (await _userManager.IsInRoleAsync(ourUser, ApplicationRoles.Admin))
                    {
                        return LocalRedirect("~/Admin/Dashboard");

                    }

                    return RedirectToAction("Index1", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(loginVM);
        }

        /// <summary>
        /// This method handles all login from an external provider such as Microsoft or Google
        /// </summary>
        /// <param name="provider">name of provider</param>
        /// <returns>A redirect view to home page or site external login callback</returns>
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {

            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }
        
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
                return RedirectToAction("Index1", "Home");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        }


        /// <summary>
        /// This method handles login if the user utilizing a third party provider has not yet registered on the site. Creates a new user and attaches claims.
        /// </summary>
        /// <param name="externalVM">Externale Login View Model</param>
        /// <returns>Home page or error message</returns>
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel externalVM)
        {
            if(ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if(info == null)
                {
                    TempData["Error"] = "Error loading information";
                }

                var user = new ApplicationUser { UserName = externalVM.Email, Email = externalVM.Email, Birthday = externalVM.Birthday, FirstName = externalVM.FirstName, LastName = externalVM.LastName, Professional = externalVM.Professional };

                var result = await _userManager.CreateAsync(user, externalVM.Password);

                if (result.Succeeded)
                {
                    // Add claims
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim professionalClaim = new Claim("Professional", user.Professional);

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, professionalClaim };

                    await _userManager.AddClaimsAsync(user, claims);
                    result = await _userManager.AddLoginAsync(user, info);
                    if(result.Succeeded)
                    {

                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index1", "Home");

                    }
                }
            }

            return View(externalVM);
        }

        /// <summary>
        /// This method logs the user out
        /// </summary>
        /// <returns>Home Page View</returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index1", "Home");
        }
    }
}