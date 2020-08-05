using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.UniversitiesRepository;

namespace Couponel.Business.Identities.Students.Services.Implementations
{
    public sealed class StudentService: IStudentService
    {
        private readonly IUniversitiesRepository _repository;
        private readonly IMapper _mapper;
        public StudentService(IUniversitiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StudentDetailsModel> GetStudentDetailsById(Guid universityId, Guid facultyId, Guid studentId)
        {
            var university = await _repository.GetByIdFacultyIdStudentIdWithStudentDetails(universityId, facultyId, studentId);
            var faculty = university.GetFaculty(facultyId);
            var student = faculty.GetStudent(studentId);
            var studentDetails = new StudentDetailsModel { UniversityName=university.Name, FacultyName= faculty.Name, User=student.User};
            return studentDetails;
        }
        public async Task CreateStudent(Guid universityId, Guid facultyId, Guid userId)
        {
            var university = await _repository.GetByIdWithFacultiesAndStudents(universityId, facultyId);
            var faculty = university.GetFaculty(facultyId);
           
            faculty.AddStudent(new Student(userId));
            _repository.Update(university);

            await _repository.SaveChanges();
        }
    }
}
