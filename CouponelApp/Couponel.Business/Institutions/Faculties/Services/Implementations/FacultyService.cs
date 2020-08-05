using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Entities;
using Couponel.Entities.Institutions;
using System.Linq;
using Couponel.Persistence.Repositories.UniversitiesRepository;

namespace Couponel.Business.Institutions.Faculties.Services.Implementations
{
    public sealed class FacultyService: IFacultyService
    {
        private readonly IUniversitiesRepository _repository;
        private readonly IMapper _mapper;

        public FacultyService(IUniversitiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FacultyModel> GetByIdWithAddress(Guid univeristyId, Guid facultyId)
        {
            var university= await _repository.GetByIdWithFacultyAndFacultyAddress(univeristyId, facultyId);
            var faculty = (IList<Faculty>)university.Faculties;
            return _mapper.Map<FacultyModel>(faculty.FirstOrDefault());
        }

        public async Task<FacultyModel> Add(CreateFacultyModel model)
        {
            var university = await _repository.GetAllDependenciesById(model.UniversityId);
            var faculty = _mapper.Map<Faculty>(model);
            university.AddFaculty(faculty);
            _repository.Update(university);
            await _repository.SaveChanges();
            return _mapper.Map<FacultyModel>(faculty);
        }
        public async Task<IEnumerable<ListFacultyModel>> GetAllByUniversityId(Guid id)
        {
            var university = await _repository.GetByIdWithFaculties(id);
            var faculties = new List<ListFacultyModel>();
            foreach (var faculty in university.Faculties)
            {
                faculties.Add(_mapper.Map<ListFacultyModel>(faculty));
            }
            return faculties;
        }
        public async Task Update(UpdateFacultyModel model)
        {
            var university = await _repository.GetByIdWithFaculties(model.UniversityId);

            university.UpdateFaculty(model.Id, _mapper.Map<Faculty>(model));

            _repository.Update(university);

            await _repository.SaveChanges();
        }
        public async Task Delete(Guid universityId, Guid facultyId)
        {
            var university = await _repository.GetAllDependenciesById(universityId);

            university.RemoveFaculty(facultyId);
            _repository.Update(university);

            await _repository.SaveChanges();
        }


    }
}
