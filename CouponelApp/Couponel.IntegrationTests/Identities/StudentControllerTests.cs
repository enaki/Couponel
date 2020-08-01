using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Couponel.Business.Identities.Offerors.Models;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Identities
{
    public class StudentControllerTests:IntegrationTests
    {

        [Fact]
        public async Task GetStudents()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var student = new Student("student","student","0321384234",address.Id);

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Students.AddAsync(student);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"student/{student.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var students = await response.Content.ReadAsAsync<OffererModel>();
            students.Should().NotBeNull();


        }


        [Fact]
        public async Task DeleteStudents()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });
            var student = new Student("student", "student", "0321384234", address.Id);

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Students.AddAsync(student);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"student/{student.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var students = await response.Content.ReadAsAsync<OffererModel>();
            students.Should().BeNull();

        }
    }
}
