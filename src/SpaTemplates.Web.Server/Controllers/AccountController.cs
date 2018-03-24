using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpaTemplates.Domain;
using SpaTemplates.Web.Server.Helpers;
using SpaTemplates.Web.Server.ViewModels;

namespace SpaTemplates.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(ErrorHelper.AddErrorsToModelState(result, ModelState));
            }

            return new OkObjectResult("Account created");
        }
    }
}