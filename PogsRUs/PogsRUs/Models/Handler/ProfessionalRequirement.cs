using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PogsRUs.Models.Handler
{
    public class ProfessionalRequirement : IAuthorizationRequirement
    {
        public string IsProfessional { get; set; }

        public ProfessionalRequirement(string isProfessional)
        {
            IsProfessional = isProfessional;
        }

        
    }
}
