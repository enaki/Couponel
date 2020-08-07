
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Couponel.API;
using Couponel.Business.Authentications.Models;
using Couponel.Business.Identities.Users.Models;
using Couponel.Entities.Identities;
using Couponel.Persistence;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Couponel.IntegrationTests
{
    public class IntegrationTests : IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;

        protected HttpClient HttpClient { get; private set; }
        protected Guid AuthenticatedUserId { get; private set; }
        protected string AdminAuthenticationToken { get; private set; }
        protected string OffererAuthenticationToken { get; private set; }

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
        public async Task InitializeAsync()
        {
            await ExecuteDatabaseAction(async (couponelContext) => await CleanupDatabase(couponelContext));
            await SetAdminAuthenticationToken();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AdminAuthenticationToken);

        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        private async Task SetAdminAuthenticationToken()
        {
            var adminRegisterModel = new UserRegisterModel
            {
                UserName = "mircea",
                Email = "mircea@yahoo.com",
                Password = "mircea",
                Role = "Admin",
                FirstName = "Mircea",
                LastName = "Ionescu",
                PhoneNumber = "0754268945"
            };
            var adminRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", adminRegisterModel);
            adminRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid(adminRegisterResponse.Headers.Location.OriginalString);
            var admin = new User("mircea","mircea@yahoo.com","mircea","Admin","Mircea","Ionescu","0754268945");
            var authenticateModel = new AuthenticationRequest
            {
                Username = admin.UserName,
                Password = adminRegisterModel.Password
            };
            var adminAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            adminAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            var authenticationResponseContent = await adminAuthenticateResponse.Content.ReadAsAsync<AuthenticationResponse>();

            AdminAuthenticationToken = authenticationResponseContent.Token;
        }

        private async Task SetOffererAuthenticationToken()
        {
            var offererRegisterModel = new UserRegisterModel
            {
                UserName = "mircea",
                Email = "mircea@yahoo.com",
                Password = "mircea",
                Role = "Offerer",
                FirstName = "Mircea",
                LastName = "Ionescu",
                PhoneNumber = "0754268945"
            };
            var offererRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", offererRegisterModel);
            offererRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid(offererRegisterResponse.Headers.Location.OriginalString);
            var offerer = new User("mircea", "mircea@yahoo.com", "mircea", "Offerer", "Mircea", "Ionescu", "0754268945");
            var authenticateModel = new AuthenticationRequest
            {
                Username = offerer.UserName,
                Password = offererRegisterModel.Password
            };
            var offererAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            offererAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            var authenticationResponseContent = await offererAuthenticateResponse.Content.ReadAsAsync<AuthenticationResponse>();

            OffererAuthenticationToken = authenticationResponseContent.Token;
        }
    }
}
