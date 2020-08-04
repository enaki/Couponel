using Couponel.Entities.Institutions;
using System;
using System.Text.Json.Serialization;

namespace Couponel.Business.Institutions.Universities.Models
{
    public sealed class CreateUniversityModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
