using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Couponel.Entities.ValueObjects;

namespace Couponel.Entities.Institutions
{
    public sealed class University : Entity
    {
        public University(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Faculties = new List<Faculty>();
        }

        [Required]
        public string Name { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Faculty> Faculties { get; private set; }
        public void AddFaculty(Faculty faculty)
        {
            Faculties.Add(faculty);
        }
        public void RemoveFaculty(Guid facultyId)
        {
            var faculty = this.Faculties.FirstOrDefault(rc => rc.Id == facultyId);
            if (faculty != null)
            {
                Faculties.Remove(faculty);
            }
        }
        public void UpdateFaculty(Guid facultyId, Faculty faculty)
        {
            var facultyDto = this.Faculties.FirstOrDefault(rc => rc.Id == facultyId);
            if(facultyDto != null)
                facultyDto.Update(faculty.Name, faculty.Email, faculty.PhoneNumber,faculty.Address);
        }
        public Faculty GetFaculty(Guid facultyId)
                => this.Faculties.FirstOrDefault(rc => rc.Id == facultyId);
        public void Update(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
