/*
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Entities.Institutions;
using Couponel.Entities.ValueObjects;
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
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var university = new University("university", "university@yahoo.com", "0456324862",address.Id);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/university/{university.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var universities = await response.Content.ReadAsAsync<UniversityModel>();
            universities.Should().NotBeNull();

        }


        [Fact]
        public async Task DeleteUniversity()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var university = new University("university", "university@yahoo.com", "0456324862", address.Id);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/university/{university.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var universities = await response.Content.ReadAsAsync<UniversityModel>();
            universities.Should().BeNull();


        }

    }
}
*/