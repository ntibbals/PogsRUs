using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Handler
{
    public class ProfessionalRequirement : AuthorizationHandler<ProfessionalRequirement>, IAuthorizationRequirement
    {
        private string _isProfessional;

        public ProfessionalRequirement(string isProfessional)
        {
            _isProfessional = isProfessional;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfessionalRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
