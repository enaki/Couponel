using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Identities.Students.Models;
using Couponel.Entities.Coupons;
using Couponel.Entities.Identities;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Coupons
{
    [Collection("Sequential")]
    public class RedeemedControllerTests:StudentIntegrationTests 
    {
        [Fact]
        public async Task GetRedeemedCoupon()
        {
            // Arrange
            var offerer = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
            var coupon = CouponModelFactory.Default();
            offerer.AddCoupon(coupon);
            var student = new Student(this.AuthenticatedUserId);
            var admin = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);
            faculty.AddStudent(student);
           
            var redeemedcoupon = new RedeemedCoupon("Used",coupon.Id);
            student.AddRedeemedCoupon(redeemedcoupon);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(admin);
                await couponelContext.Users.AddAsync(offerer);
                await couponelContext.Universities.AddAsync(university); 
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"/api/redeemedCoupons/{redeemedcoupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var redeemedcoupons = await response.Content.ReadAsAsync<RedeemedCoupon>();
            redeemedcoupons.Should().NotBeNull();

        }
        [Fact]
        public async Task UpdateRedeemedCoupon()
        {
            // Arrange
            var offerer = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
            var coupon = CouponModelFactory.Default();
            offerer.AddCoupon(coupon);
            var student = new Student(this.AuthenticatedUserId);
            var admin = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);
            faculty.AddStudent(student);

            var redeemedcoupon = new RedeemedCoupon("Used", coupon.Id);
            student.AddRedeemedCoupon(redeemedcoupon);
            redeemedcoupon.UpdateStatus("Expired");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(admin);
                await couponelContext.Users.AddAsync(offerer);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"/api/redeemedCoupons/{redeemedcoupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var redeemedcoupons = await response.Content.ReadAsAsync<RedeemedCoupon>();
            redeemedcoupons.Status.Should().BeEquivalentTo("Expired");

        }
        [Fact]
        public async Task DeleteRedeemedCoupon()
        {
            // Arrange
            var offerer = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
            var coupon = CouponModelFactory.Default();
            offerer.AddCoupon(coupon);
            var student = new Student(this.AuthenticatedUserId);
            var admin = UserRegisterModelFactory.getUserFactory("Admin").getUser();
            var university = InstitutionsModelFactory.University();
            var faculty = InstitutionsModelFactory.Faculty();
            university.AddFaculty(faculty);
            faculty.AddStudent(student);

            var redeemedcoupon = new RedeemedCoupon("Used", coupon.Id);
            student.AddRedeemedCoupon(redeemedcoupon);
            redeemedcoupon.UpdateStatus("Expired");
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(admin);
                await couponelContext.Users.AddAsync(offerer);
                await couponelContext.Universities.AddAsync(university);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"/api/redeemedCoupons/{redeemedcoupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var redeemedcoupons = await response.Content.ReadAsAsync<RedeemedCoupon>();
            redeemedcoupons.Should().BeNull();

        }
    }
}
