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
        [Authorize(Policy = "ProfessionalsOnly")]
        public IActionResult Professionals()
        {
            return View();
        }

    }
}
