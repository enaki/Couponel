﻿using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Couponel.Business.Institutions.Faculties.Models
{
    public sealed class FacultyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
