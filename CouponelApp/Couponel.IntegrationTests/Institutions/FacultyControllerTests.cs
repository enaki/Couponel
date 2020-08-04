using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Entities.Institutions;
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
            var university = new University("university", "university@yahoo.com", "0456324862");
            var faculty = new Faculty("facultate", "facultate@yahoo.com", "0745624578");
            university.AddFaculty(faculty);
            await ExecuteDatabaseAction(async couponelContext =>
            {
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
            var university = new University("university", "university@yahoo.com", "0456324862");
            var faculty = new Faculty("facultate", "facultate@yahoo.com", "0745624578");
            faculty.Update("faculty","facultate@yahoo.com", "0745624578", new Address("Romania", "Iasi", "Bucuriei", "42"));
            university.AddFaculty(faculty);
            await ExecuteDatabaseAction(async couponelContext =>
            {
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
            var university = new University("university", "university@yahoo.com", "0456324862");
            var faculty = new Faculty("facultate", "facultate@yahoo.com", "0745624578");
            university.AddFaculty(faculty);

            await ExecuteDatabaseAction(async couponelContext =>
            {
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
