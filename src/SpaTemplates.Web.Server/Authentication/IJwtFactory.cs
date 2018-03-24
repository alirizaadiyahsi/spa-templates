using System.Security.Claims;
using System.Threading.Tasks;

namespace SpaTemplates.Web.Server.Authentication
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);

        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}