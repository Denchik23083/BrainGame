using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace BrainGame.Tests.Users.UsersApiConfiguration
{
    public class UsersApiTestBase
    {
        protected readonly HttpClient HttpClient;

        private const string SecretKey = "SuperSecuritySecretKey";

        public UsersApiTestBase()
        {
            var app = new UsersApiFactory();
            HttpClient = app.CreateDefaultClient();
        }

        protected void AddTokenWithPermissions(IEnumerable<PermissionType> permissions)
        {
            var user = GenerateUserWithPermissions(permissions);
            var token = GetUserToken(user);

            HttpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);
        }

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

        protected User GenerateUserWithPermissions(IEnumerable<PermissionType> permissions)
        {
            return new User
            {
                Email = "testemail@gmail.com",
                Name = "testname",
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
