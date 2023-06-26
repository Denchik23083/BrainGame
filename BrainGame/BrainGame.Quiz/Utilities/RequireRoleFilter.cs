using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BrainGame.Quiz.Utilities
{
    public class RequireRoleFilter : IAuthorizationFilter
    {
        private readonly Claim _requiredClaim;

        public RequireRoleFilter(Claim requiredClaim)
        {
            _requiredClaim = requiredClaim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasRole = context.HttpContext.User
                .HasClaim(c => c.Type == _requiredClaim.Type
                            && c.Value == _requiredClaim.Value);

            if (!hasRole)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
