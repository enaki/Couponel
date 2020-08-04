using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Couponel.Business.Institutions.Faculties.Models
{
    public sealed class UpdateFacultyModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

    }
}
