using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Entities;
using Couponel.Persistence.FacultiesRepository;

namespace Couponel.Business.Institutions.Faculties.Services.Implementations
{
    public sealed class FacultyService: IFacultyService
    {
        private readonly IFacultiesRepository _repository;
        private readonly IMapper _mapper;

        public FacultyService(IFacultiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FacultyModel> GetById(Guid facultyId)
        {
            var faculty = await _repository.GetById(facultyId);
            return _mapper.Map<FacultyModel>(faculty);
        }

        public async Task<FacultyModel> Add(CreateFacultyModel model)
        {
            var faculty = _mapper.Map<Faculty>(model);

            await _repository.Add(faculty);
            await _repository.SaveChanges();

            return _mapper.Map<FacultyModel>(faculty);
        }

        public async Task Delete(Guid facultyId)
        {
            var faculty = await _repository.GetById(facultyId);

            _repository.Delete(faculty);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<FacultyModel>> GetAll()
        {
            var faculties = _repository.GetAll();
            return await (Task<IEnumerable<FacultyModel>>)_mapper.Map<IEnumerable<FacultyModel>>(faculties);
        }
    }
}
