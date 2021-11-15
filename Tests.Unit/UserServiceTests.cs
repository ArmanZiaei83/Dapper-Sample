using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Services.User;
using Test.Tools;
using Xunit;

namespace Tests.Unit
{
    public class UserServiceTests
    {
        private readonly UserAppService _sut;

        public UserServiceTests()
        {
            _sut = UserFactory.CreateService();
        }

        [Fact]
        public async Task Get_gets_all_users_properly()
        {
            var list = await _sut.GetAll();

            var expected = list.Single(_ => _.Id == 1);
            expected.Name.Should().Be("test");
        }
    }
}