/*
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Entities.Institutions;
using Couponel.Entities.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Institutions
{
    public class FacultyControllerTests : IntegrationTests
    {

        [Fact]
        public async Task GetFaculty()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var faculty = new Faculty("facultate", "facultate@yahoo.com", "0745624578", address.Id);

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Faculties.AddAsync(faculty);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/faculty/{faculty.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var faculties = await response.Content.ReadAsAsync<FacultyModel>();
            faculties.Should().NotBeNull();

        }


        [Fact]
        public async Task DeleteFaculty()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var faculty = new Faculty("facultate", "facultate@yahoo.com", "0745624578",address.Id);

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Faculties.AddAsync(faculty);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/faculty/{faculty.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var faculties = await response.Content.ReadAsAsync<FacultyModel>();
            faculties.Should().BeNull();

        }
    }
}
*/