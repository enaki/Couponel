using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Couponel.Business.Identities.Admins.Models;
using Couponel.Business.Identities.Offerors.Models;
using Couponel.Entities.Identities.UserTypes;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Identities
{
    public class OffererControllerTests:IntegrationTests
    {
        [Fact]
        public async Task GetOfferers()
        {
            // Arrange
            var offerer = new Offerer("Nume", "prenume", "43213213122");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Offerers.AddAsync(offerer);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"offerer/{offerer.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var offerors = await response.Content.ReadAsAsync<OffererModel>();
            offerors.Should().NotBeNull();


        }


        [Fact]
        public async Task DeleteOfferers()
        {
            // Arrange
            var offerer = new Offerer("Nume", "prenume", "43213213122");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Offerers.AddAsync(offerer);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"offerer/{offerer.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var offerors = await response.Content.ReadAsAsync<OffererModel>();
            offerors.Should().BeNull();

        }
    }
}
