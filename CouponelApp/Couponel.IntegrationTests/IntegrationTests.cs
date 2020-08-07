
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Couponel.API;
using Couponel.Business.Authentications.Models;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;
using Couponel.IntegrationTests.Shared;
using Couponel.Persistence;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Couponel.IntegrationTests
{
    public static class UserRole{
        public const string User = "User";
        public const string Admin = "Admin";
        public const string Offerer = "Offerer";
    }

    public abstract class IntegrationTests : IAsyncLifetime
    {
        protected readonly WebApplicationFactory<Startup> _webApplicationFactory;

        protected HttpClient HttpClient { get; set; }
        protected Guid AuthenticatedUserId { get; set; }
        protected string UserAuthenticationToken { get; set; }

        public IntegrationTests()
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
            HttpClient = _webApplicationFactory.CreateClient();
        }

        protected async Task ExecuteDatabaseAction(Func<CouponelContext, Task> databaseAction)
        {
            using (var scope = _webApplicationFactory.Services.CreateScope())
            {
                var couponelContext = scope.ServiceProvider.GetRequiredService<CouponelContext>();

                await databaseAction(couponelContext);
            }
        }

        public async Task CleanupDatabase(CouponelContext couponelContext)
        {
            couponelContext.Comments.RemoveRange(couponelContext.Comments);
            couponelContext.Coupons.RemoveRange(couponelContext.Coupons);
            couponelContext.Faculties.RemoveRange(couponelContext.Faculties);
            couponelContext.Photos.RemoveRange(couponelContext.Photos);
            couponelContext.RedeemedCoupons.RemoveRange(couponelContext.RedeemedCoupons);
            couponelContext.Students.RemoveRange(couponelContext.Students);
            couponelContext.Universities.RemoveRange(couponelContext.Universities);
            couponelContext.Users.RemoveRange(couponelContext.Users);
            await couponelContext.SaveChangesAsync();
        }

        public abstract Task InitializeAsync();

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        protected async Task<(Guid, string)> SetAuthenticationToken(string role)
        {
            var userFactory = UserRegisterModelFactory.getUserFactory(role);

            var userRegisterModel = userFactory.getUserModel();
            var userRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", userRegisterModel);
            userRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            var user = userFactory.getUser();
            var authenticatedUserId = new Guid(userRegisterResponse.Headers.Location.OriginalString);
            var authenticateModel = new AuthenticationRequest
            {
                Username = user.UserName,
                Password = userRegisterModel.Password
            };
            
            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            var authenticationResponseContent = await userAuthenticateResponse.Content.ReadAsAsync<AuthenticationResponse>();
            var userAuthenticationToken = authenticationResponseContent.Token;
            return (authenticatedUserId, userAuthenticationToken);
        }
    }
}
