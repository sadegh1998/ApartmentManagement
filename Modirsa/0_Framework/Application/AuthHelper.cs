using _0_Framework.Infrstructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long CurrentAccountId()
        {
            if (IsAuthenticated())
            {
                return long.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId")?.Value);
            }

            return 0;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
            {
                return result;
            }
            
            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = Guid.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.UserName = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            result.FullName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            result.RoleId = Guid.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Role = Roles.GetRoleBy(result.RoleId);
            return result;
        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
            {
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            }

            return null;
        }

        public List<int> GetPermissions()
        {
            if (!IsAuthenticated())
            {
                return new List<int>();
            }
            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            // return claims.Count > 0;
        }

        public void SignIn(AuthViewModel auth)
        {
            var permissions = JsonConvert.SerializeObject(auth.Permissions);
            var clamis = new List<Claim>
            {
                new Claim("AccountId",auth.Id.ToString()),
                new Claim(ClaimTypes.Name , auth.FullName),
                new Claim(ClaimTypes.Role , auth.RoleId.ToString()),
                new Claim("Username" , auth.UserName),
                new Claim("Permissions" , permissions)
            };

            var claimIdentity = new ClaimsIdentity(clamis, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
