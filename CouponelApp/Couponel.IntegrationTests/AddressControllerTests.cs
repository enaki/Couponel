using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Couponel.API.Controllers;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Entities;
using Couponel.Persistence;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Couponel.IntegrationTests
{
    public class AddressControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetAddress()
        {
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");

            await ExecuteDatabaseAction(async (couponelContext) =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"api/address/{address.Id}");

            response.IsSuccessStatusCode.Should().BeTrue();
           
            var addresses = await response.Content.ReadAsAsync<IList<AddressModel>>();

            addresses.Should().HaveCount(1);

        }
    }

}
