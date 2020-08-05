using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Couponel.Entities.Identities;
using Couponel.Entities.ValueObjects;

namespace Couponel.Entities.Institutions
{
    public sealed class Faculty : Entity
    {
        public Faculty(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Students = new List<Student>();
        }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Student> Students { get; private set; }
        public void Update(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Guid studentId)
        {
            var faculty = this.Students.FirstOrDefault(rc => rc.Id == studentId);
            if (faculty != null)
            {
                Students.Remove(faculty);
            }
        }
        public Student GetStudent(Guid stuentId)
                => this.Students.FirstOrDefault(rc => rc.Id == stuentId);
    }
}
