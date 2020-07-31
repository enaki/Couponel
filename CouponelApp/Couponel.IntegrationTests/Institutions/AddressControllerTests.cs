﻿using System.Net.Http;
using System.Threading.Tasks;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Entities.Institutions;
using FluentAssertions;
using Xunit;

namespace Couponel.IntegrationTests.Institutions
{
    public class AddressControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetAddress()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/address/{address.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var addresses = await response.Content.ReadAsAsync<AddressModel>();
            addresses.Should().NotBeNull();

        }


        [Fact]
        public async Task DeleteAddress()
        {
            // Arrange
            var address = new Address("Romania", "Iasi", "Bucuriei", "42");

            await ExecuteDatabaseAction(async couponelContext =>
            {
                await couponelContext.Addresses.AddAsync(address);
                await couponelContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/address/{address.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var addresses = await response.Content.ReadAsAsync<AddressModel>();
            addresses.Should().BeNull();

        }
    }

}