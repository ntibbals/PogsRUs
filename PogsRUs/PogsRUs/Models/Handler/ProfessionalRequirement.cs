using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models.Handler
{
    public class ProfessionalRequirement : AuthorizationHandler<ProfessionalRequirement>, IAuthorizationRequirement
    {
        private bool _isProfessional;

        public ProfessionalRequirement(bool isProfessional)
        {
            _isProfessional = isProfessional;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfessionalRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
