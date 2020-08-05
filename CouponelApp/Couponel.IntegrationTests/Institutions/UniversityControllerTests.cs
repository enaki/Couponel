/*
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Entities.Institutions;
using Couponel.Entities.ValueObjects;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace Couponel.IntegrationTests.Institutions
{
    public class UniversityControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetUniversity()
        {
            // Arrange
            var university = new University("university", "university@yahoo.com", "0456324862");
            await ExecuteDatabaseAction(async couponelContext =>
            {
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
            var university = new University("university", "university@yahoo.com", "0456324862");
            university.Update("university", "university@yahoo.com", "0456324862",new Address("Romania","Iasi","Bucuriei","42"));
            await ExecuteDatabaseAction(async couponelContext =>
            {
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
            var university = new University("university", "university@yahoo.com", "0456324862");
            await ExecuteDatabaseAction(async couponelContext =>
            {
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
*/