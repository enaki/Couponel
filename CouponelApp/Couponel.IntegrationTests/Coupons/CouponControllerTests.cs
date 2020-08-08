using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.IntegrationTests.Shared;
using Couponel.IntegrationTests.SpecificIntegrationTests;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Coupons
{
    [Collection("Sequential")]
    public class CouponControllerTests: OffererIntegrationTests
    {
        [Fact]
        public async Task OffererGetCoupon()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

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
        [Fact]
        public async Task OffererUpdateCoupon()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            coupon.Update("da","electronice", new DateTime(2022,04,12,12,32,12),"descriere" );
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
            coupons.Name.Should().Be("da");
        }
        [Fact]
        public async Task OffererDeleteCoupon()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/coupons/{coupon.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var coupons = await response.Content.ReadAsAsync<CouponModel>();
            coupons.Should().BeNull();
        }

    }
}
