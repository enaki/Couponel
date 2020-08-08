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
    public class CommentsControllerTests: OffererIntegrationTests
    {
        [Fact]
        public async Task OffererGetComment()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            var comment=new Comment("content",AuthenticatedUserId);
            coupon.AddComment(comment);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/coupons/{coupon.Id}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CouponModel>>();
            comments.Should().HaveCount(1);

        }
        [Fact]
        public async Task OffererDeleteComment()
        {
            // Arrange
            var user = UserRegisterModelFactory.getUserFactory("Offerer").getUser();

            var coupon = CouponModelFactory.Default();
            user.AddCoupon(coupon);
            var comment = new Comment("content", AuthenticatedUserId);
            coupon.AddComment(comment);
            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Users.AddAsync(user);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/coupons/{coupon.Id}/comments/{comment.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CouponModel>>();
            comments.Should().BeNull();

        }
    }
}
