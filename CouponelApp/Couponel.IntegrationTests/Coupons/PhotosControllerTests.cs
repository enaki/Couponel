using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
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
    public class PhotosControllerTests: OffererIntegrationTests
    {
        [Fact]
        public async Task OffererDeletePhoto()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();
            var photo= new Photo("Photo", File.ReadAllBytes("G:\\Centric Couponel\\Couponel\\CouponelApp\\Couponel.IntegrationTests\\Photo\\image.jpeg"), user.Id);
            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            coupon.AddPhoto(photo);
            coupon.RemovePhoto(photo.Id);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/coupons/{coupon.Id}/photos/{photo.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var photos = await response.Content.ReadAsAsync<IList<CouponModel>>();
            photos.Should().BeNull();

        }
    }
}
