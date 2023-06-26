using BrainGame.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrainGame.Quiz.Utilities
{
    public class RequireRoleAttribute : TypeFilterAttribute
    {
        public RequireRoleAttribute(Role role) : base(typeof(RequireRoleFilter))
        {
            Arguments = new object[] { new Claim(ClaimTypes.Role, role.ToString()) };
        }
    }
}
