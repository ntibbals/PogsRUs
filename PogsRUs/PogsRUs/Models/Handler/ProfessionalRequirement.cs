using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.Anonymous))
            {
                return Task.CompletedTask;
            }

            string proStatus = context.User.FindFirst(u => u.Type == ClaimTypes.Anonymous).ToString();

            if (proStatus == _isProfessional)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
