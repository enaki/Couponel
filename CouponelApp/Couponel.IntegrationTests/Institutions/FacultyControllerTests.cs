
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Institutions
{
    [Collection("Sequential")]
    public class FacultyControllerTests : AdminIntegrationTests
    {
        [Fact]
        public async Task GetFaculty()
        {
            // Arrange
            var adminFactory = UserRegisterModelFactory.getUserFactory("Admin");
            var user = adminFactory.getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/universities/{university.Id}/faculties/{faculty.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var faculties = await response.Content.ReadAsAsync<FacultyModel>();
            faculties.Should().NotBeNull();

        }
        [Fact]
        public async Task UpdateFaculty()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            faculty.Update("faculty", "facultate@yahoo.com", "0745624578", InstitutionsModelFactory.Address());
            university.AddFaculty(faculty);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/universities/{university.Id}/faculties/{faculty.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var faculties = await response.Content.ReadAsAsync<FacultyModel>();
            faculties.Should().NotBeNull();
            faculties.Name.Should().BeEquivalentTo("faculty");

        }


        [Fact]
        public async Task DeleteFaculty()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/universities/{university.Id}/faculties/{faculty.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var faculties = await response.Content.ReadAsAsync<FacultyModel>();
            faculties.Should().BeNull();

        }
    }
}
