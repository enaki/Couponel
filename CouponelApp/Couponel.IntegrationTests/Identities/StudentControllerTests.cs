using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Authentications.Models;
using Couponel.Business.Identities.Students.Models;
using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Identities
{
    [Collection("Sequential")]
    public class StudentControllerTests: StudentIntegrationTests
    {
        [Fact]
        public async Task GetAdminUser()
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

        [Fact]
        public async Task GetOffererUser()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
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
        [Fact]
        public async Task GetStudentUser()
        {
            // Arrange
            var admin = UserRegisterModelFactory.getUserFactory("admin").getUser();
            var user = UserRegisterModelFactory.getUserFactory("Student").getUser();
            var student=new Student(user.Id);
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);
            faculty.AddStudent(student);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(admin);
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/users/{user.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var users = await response.Content.ReadAsAsync<StudentModel>();
            users.Should().NotBeNull();

        }
    }
}
