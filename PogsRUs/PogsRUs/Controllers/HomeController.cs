using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PogsRUs.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This metho is our landing page to site
        /// </summary>
        /// <returns>Home landing page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method takes user to customer facing home page
        /// </summary>
        /// <returns>Home page view</returns>
        public IActionResult Index1()
        {
            return View();
        }
    }
}