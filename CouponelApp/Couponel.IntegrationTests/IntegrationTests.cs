using System;
using System.Net.Http;
using System.Threading.Tasks;
using Couponel.API;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Entities.Institutions;
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

        public IntegrationTests()
        {
            _webApplicationFactory=new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
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
            couponelContext.Addresses.RemoveRange(couponelContext.Addresses);
            couponelContext.Admins.RemoveRange(couponelContext.Admins);
            couponelContext.Comments.RemoveRange(couponelContext.Comments);
            couponelContext.Coupons.RemoveRange(couponelContext.Coupons);
            couponelContext.Faculties.RemoveRange(couponelContext.Faculties);
            couponelContext.Offerors.RemoveRange(couponelContext.Offerors);
            couponelContext.Students.RemoveRange(couponelContext.Students);
            couponelContext.Universities.RemoveRange(couponelContext.Universities);
            couponelContext.Users.RemoveRange(couponelContext.Users);
            await couponelContext.SaveChangesAsync();
        }
        public async Task InitializeAsync()
        {
            await ExecuteDatabaseAction(async (couponelContext) => await CleanupDatabase(couponelContext));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
