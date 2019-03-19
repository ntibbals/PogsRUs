using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PogsRUs.Models.Handler
{
    public class ProfessionalHandler : AuthorizationHandler<ProfessionalRequirement>
    {
        /// <summary>
        /// This method handles requirements for professional policy
        /// </summary>
        /// <param name="context">Authorization handler context</param>
        /// <param name="requirement">professional requirement</param>
        /// <returns>task completed</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfessionalRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Professional"))
            {
                return Task.CompletedTask;
            }

            string proStatus = context.User.FindFirst(u => u.Type == "Professional").Value;

            if (proStatus == requirement.IsProfessional)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
