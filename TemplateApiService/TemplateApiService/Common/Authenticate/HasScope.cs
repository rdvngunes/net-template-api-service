using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateApiService.Common.Authenticate
{
    public class HasScope : AuthorizationHandler<HasScope>, IAuthorizationRequirement
    {
        private readonly string issuer;
        private readonly string scopes;

        /// <summary>
        /// Constructor for the HasScope class.
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="scopes"></param>
        public HasScope(string _scopes, string _issuer)
        {
            this.scopes = _scopes;
            this.issuer = _issuer;
        }

        /// <summary>
        /// To handel the token claims.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScope requirement)
        {
            // If user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "scope"))
                return Task.CompletedTask;

            var contextScopes = context.User.Claims.Where(c => c.Type == "scope").FirstOrDefault().Value.Split(" ");

            // Succeed if the scope array contains the required scope
            if (contextScopes.Contains(scopes))
            {
                context.Succeed(requirement);
            }
            // context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
