using Microsoft.EntityFrameworkCore;
using NSubstitute;
using SpaTemplates.Application.Users;
using Xunit;

namespace SpaTemplates.Application.Tests
{
    public class UserApplicationServiceTests : TestBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserApplicationServiceTests()
        {
            //todo: mock appservice dependencies
            _userApplicationService = Substitute.For<IUserApplicationService>();
            _userApplicationService.GetAllAsync()
                .Returns(GetInitializedDbContext().Users.ToListAsync());
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
