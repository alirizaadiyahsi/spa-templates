using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;
using SpaTemplates.EntityFrameworkCore;

namespace SpaTemplates.Application.Users
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        public UserApplicationService(IRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
