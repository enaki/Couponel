using System;
using System.Collections.Generic;
using Couponel.Entities.Institutions;

namespace Couponel.Business.Institutions.Universities.Models
{
    public sealed class ListUniversityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Faculty> Faculties { get; set; }
    }
}
