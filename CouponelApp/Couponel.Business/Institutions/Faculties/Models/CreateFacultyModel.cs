using Couponel.Entities.Institutions;
using System;
using System.Text.Json.Serialization;
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Institutions.Faculties.Models
{
    public sealed class CreateFacultyModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public Guid UniversityId { get; set; }
        public Address Address{ get; set; }
    }
}
