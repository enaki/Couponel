/*
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Identities.Admins.Models;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Identities
{
    public class AdminsControllerTests:IntegrationTests
    {
        [Fact]
        public async Task GetAdmin()
        {
            // Arrange
            var admin = new Admin("Admin", "Admin", "43213213122");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Admins.AddAsync(admin);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"admin/{admin.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var admins = await response.Content.ReadAsAsync<AdminModel>();
            admins.Should().NotBeNull();

        }


        [Fact]
        public async Task DeleteAdmin()
        {
            var admin = new Admin("Admin", "Admin", "43213213122");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Admins.AddAsync(admin);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"admin/{admin.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var admins = await response.Content.ReadAsAsync<AdminModel>();
            admins.Should().BeNull();

        }
    }
}
*/