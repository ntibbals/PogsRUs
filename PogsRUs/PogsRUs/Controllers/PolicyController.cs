using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Controllers
{
    [Authorize]
    public class PolicyController : Controller
    {
        /// <summary>
        /// This is our professional policy page
        /// </summary>
        /// <returns>Professional page if authorized</returns>
        [Authorize(Policy = "ProfessionalsOnly")]
        public IActionResult Professionals()
        {
            return View();
        }

        /// <summary>
        /// This is our admin dashboard
        /// </summary>
        /// <returns>Authorized view for admin</returns>
        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

    }
}
