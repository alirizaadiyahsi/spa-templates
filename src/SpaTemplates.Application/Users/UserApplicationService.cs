using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;
using SpaTemplates.EntityFrameworkCore;

namespace SpaTemplates.Application.Users
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ApplicationUser> _userRepository;

        public UserApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.GetRepository<ApplicationUser>();
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
