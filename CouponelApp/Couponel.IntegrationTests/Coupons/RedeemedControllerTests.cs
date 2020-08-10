using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Entities.Coupons;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Coupons
{
    [Collection("Sequential")]
    public class RedeemedControllerTests:OffererIntegrationTests
    {
        [Fact]
        public async Task GetRedeemedCoupon()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            var redeemedcoupon=new RedeemedCoupon("Used",coupon.Id);
           
            var student = UserRegisterModelFactory.getUserFactory("Student").getUser();
            student.AddCoupon(coupon);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.Users.AddAsync(student);
                await couponelContext.RedeemedCoupons.AddAsync(redeemedcoupon);
                await couponelContext.SaveChangesAsync();
            });
            //Act
            var response = await HttpClient.GetAsync($"api/redeemedCoupons/{coupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CouponModel>>();
            comments.Should().NotBeNull();

        }
    }
}
