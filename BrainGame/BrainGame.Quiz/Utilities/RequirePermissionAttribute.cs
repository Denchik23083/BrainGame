using BrainGame.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrainGame.Quiz.Utilities
{
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        public RequirePermissionAttribute(PermissionType permissionType) : base(typeof(RequireClaimFilter))
        {
            Arguments = new object[] { new Claim("permission", permissionType.ToString()) };
        }
    }
}
