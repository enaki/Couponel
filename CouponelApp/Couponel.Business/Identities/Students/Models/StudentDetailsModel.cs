using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Identities.Students.Models
{
    public sealed class StudentDetailsModel
    {
        public string UniversityName { get; set; }
        public string FacultyName { get; set; }
        public User User { get; set; }
    }
}
