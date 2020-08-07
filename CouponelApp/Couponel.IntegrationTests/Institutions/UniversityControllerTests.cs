
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.IntegrationTests.Shared;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Institutions
{
    public class UniversityControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetUniversity()
        {
            // Arrange
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/universities/{university.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var universities = await response.Content.ReadAsAsync<UniversityModel>();
            universities.Address.Should().BeNull();
            universities.Should().NotBeNull();

        }

        [Fact]
        public async Task UpdateUniversity()
        {
            // Arrange
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            university.Update("university", "university@yahoo.com", "0456324862", AddressModelFactory.Default());
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/universities/{university.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var universities = await response.Content.ReadAsAsync<UniversityModel>();
            universities.Address.Street.Should().Be("Bucuriei");
        }


        [Fact]
        public async Task DeleteUniversity()
        {
            // Arrange
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/universities/{university.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var universities = await response.Content.ReadAsAsync<UniversityModel>();
            universities.Should().BeNull();


        }

    }
}
