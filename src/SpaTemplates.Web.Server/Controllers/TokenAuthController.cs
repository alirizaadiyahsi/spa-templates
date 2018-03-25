using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaTemplates.Domain;
using SpaTemplates.Web.Server.AppConsts;
using SpaTemplates.Web.Server.Authentication.JwtBearer;
using SpaTemplates.Web.Server.ViewModels;

namespace SpaTemplates.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenAuthConfiguration _tokenAuthConfiguration;

        public TokenAuthController(
            UserManager<ApplicationUser> userManager,
            IOptions<TokenAuthConfiguration> tokenAuthConfiguration)
        {
            _userManager = userManager;
            _tokenAuthConfiguration = tokenAuthConfiguration.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userToVerify = await GetClaimsIdentity(loginViewModel.UserName, loginViewModel.Password);
            if (userToVerify == null)
            {
                return Unauthorized();
            }

            var token = new JwtSecurityToken
            (
                issuer: _tokenAuthConfiguration.Issuer,
                audience: _tokenAuthConfiguration.Audience,
                claims: userToVerify.Claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: _tokenAuthConfiguration.SigningCredentials
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var userToVerify = await _userManager.FindByNameAsync(userName);
            if (userToVerify == null)
            {
                return null;
            }

            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(SpaTemplatesClaimTypes.Role,SpaTemplatesClaimValues.ApiAccess),
                });
            }

            return null;
        }
    }
}