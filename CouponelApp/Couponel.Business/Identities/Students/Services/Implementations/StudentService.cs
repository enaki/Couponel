using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Entities.Identities;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.UniversitiesRepository;

namespace Couponel.Business.Identities.Students.Services.Implementations
{
    public sealed class StudentService : IStudentService
    {
        private readonly IUniversitiesRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IUniversitiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDetailsModel> GetStudentDetailsById(Guid studentId)
        {
            var university = await _repository.GetByStudentId(studentId);
            var faculties = (IEnumerable<Faculty>)university.Faculties;
            var faculty = faculties.FirstOrDefault();

            var students = (IEnumerable<Student>) faculty?.Students;
            var student = students?.FirstOrDefault();

            return student == null ? null : new StudentDetailsModel{UniversityName = university.Name, FacultyName = faculty.Name, User = student.User};
        }
    }
}
