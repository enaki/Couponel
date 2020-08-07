using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.ValueObjects;

namespace Couponel.IntegrationTests.Shared
{
    public static class AddressModelFactory
    {
        public static Address Default()
        {
            return new Address("Romania", "Iasi", "Bucuriei", "42");
        }
    }
}
