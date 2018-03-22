using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;

namespace SpaTemplates.Application.Users
{
    public interface IUserApplicationService
    {
        Task<List<ApplicationUser>> GetAllAsync();
    }
}