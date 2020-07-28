using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.IdentitiesRepositories.StudentsRepository;

namespace Couponel.Business.Identities.Students.Services.Implementations
{
    public sealed class StudentService: IStudentService
    {
        private readonly IStudentsRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentModel> GetById(Guid studentId)
        {
            var student = await _repository.GetById(studentId);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<StudentModel> Add(CreateStudentModel model)
        {
            var student = _mapper.Map<Student>(model);

            await _repository.Add(student);
            await _repository.SaveChanges();

            return _mapper.Map<StudentModel>(student);
        }

        public async Task Delete(Guid studentId)
        {
            var student = await _repository.GetById(studentId);

            _repository.Delete(student);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            var students = _repository.GetAll();
            return await (Task<IEnumerable<StudentModel>>)_mapper.Map<IEnumerable<StudentModel>>(students);
        }
    }
}
