using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BrainGame.Quiz.Utilities
{
    public class RequireClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _requiredClaim;

        public RequireClaimFilter(Claim requiredClaim)
        {
            _requiredClaim = requiredClaim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User
                .HasClaim(c => c.Type == _requiredClaim.Type
                            && c.Value == _requiredClaim.Value);

            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
