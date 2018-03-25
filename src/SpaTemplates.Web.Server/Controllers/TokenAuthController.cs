using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpaTemplates.Domain;
using SpaTemplates.Web.Server.ViewModels;

namespace SpaTemplates.Web.Server.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenAuthController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody]LoginViewModel credentials)
        //{
            
        //}
    }
}