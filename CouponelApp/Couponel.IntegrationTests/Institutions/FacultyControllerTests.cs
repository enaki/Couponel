
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.IntegrationTests.Shared;
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
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            var faculty = FacultyModelFactory.Default();
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
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            var faculty = FacultyModelFactory.Default();
            faculty.Update("faculty", "facultate@yahoo.com", "0745624578", AddressModelFactory.Default());
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
            var user = UserRegisterModelFactory.Admin();
            var university = UniversityModelFactory.Default();
            var faculty = FacultyModelFactory.Default();
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
