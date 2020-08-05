using Couponel.Entities.Institutions;
using System;
using System.Collections;
using System.Collections.Generic;
using Couponel.Entities.ValueObjects;

namespace Couponel.Business.Institutions.Universities.Models
{
    public sealed class UniversityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
