using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public void Insert()
        {
            var appuser = new ApplicationUser()
            {
                UserName = Guid.NewGuid().ToString()
            };

            _userRepository.Insert(appuser);
        }
    }
}
