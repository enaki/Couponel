using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.IntegrationTests.Shared;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Coupons
{
    public class CouponControllerTests:IntegrationTests
    {
        [Fact]
        public async Task OffererGetCoupon()
        {
            // Arrange
            var user = UserRegisterModelFactory.Offerer();
            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/coupons/{coupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var coupons = await response.Content.ReadAsAsync<CouponModel>();
            coupons.Should().Should().NotBeNull();

        }
    }
}
