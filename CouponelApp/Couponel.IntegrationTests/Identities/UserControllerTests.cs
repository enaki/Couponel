using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Authentications.Models;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Identities
{
    [Collection("Sequential")]
    public class UserControllerTests: UserIntegrationTests
    {
        [Fact]
        public async Task GetUser()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/users/{user.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var users = await response.Content.ReadAsAsync<UserModel>();
            users.Should().NotBeNull();

        }
    }
}
