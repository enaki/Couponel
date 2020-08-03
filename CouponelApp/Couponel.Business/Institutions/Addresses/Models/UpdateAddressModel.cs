using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Couponel.Business.Institutions.Addresses.Models
{
    public sealed class UpdateAddressModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}
