using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrainGame.Tests.Utilities
{
    public class AddTokenWithPermissions
    {
        private const string SecretKey = "SuperSecuritySecretKey";

        protected string GetUserToken(User user)
        {
            var secret = Encoding.UTF8.GetBytes(SecretKey);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new (ClaimTypes.Name, user.Name!),
                new (ClaimTypes.Email, user.Email!),
                new (ClaimTypes.Gender, user.Gender!.Type.ToString()!),
                new (ClaimTypes.Role, user.Role!.RoleType.ToString()!)
            };

            var permissions = user.Role!.RolePermissions!
                .Select(_ => new Claim("permission", _.PermissionType.ToString()!));

            claims.AddRange(permissions);

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                notBefore: now,
                expires: now.AddMinutes(5),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return stringToken;
        }

        protected User UserWithPermissions(IEnumerable<PermissionType> permissions)
        {
            return new User
            {
                Id = 1,
                Name = "God",
                Email = "god@gmail.com",
                Gender = new Gender { Type = GenderType.Male },
                Password = "0000",
                Role = new Role
                {
                    RolePermissions = permissions.Select(p => new RolePermission
                    {
                        PermissionType = p
                    }).ToList(),
                }
            };
        }
    }
}
