using Microsoft.EntityFrameworkCore;
using NSubstitute;
using SpaTemplates.Application.Users;
using SpaTemplates.Domain;
using SpaTemplates.EntityFrameworkCore;
using Xunit;

namespace SpaTemplates.Application.Tests
{
    public class UserApplicationServiceTests : TestBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserApplicationServiceTests()
        {
            //todo: mock appservice dependencies
            var userRepository = Substitute.For<IRepository<ApplicationUser>>();
            userRepository.GetAllAsync()
                .Returns(GetInitializedDbContext().Users.ToListAsync());
            _userApplicationService = new UserApplicationService(userRepository);
        }

        [Fact]
        public async void TestGetAll()
        {
            var users = await _userApplicationService.GetAllAsync();
            Assert.NotNull(users);
            Assert.Equal(6, users.Count);
        }
    }
}
