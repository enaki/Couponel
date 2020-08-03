using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Faculties.Models;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Entities;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.CouponsRepositories.RedeemedCouponsRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.AddressesRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.FacultiesRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository;

namespace Couponel.Business.Institutions.Faculties.Services.Implementations
{
    public sealed class FacultyService: IFacultyService
    {
        private readonly IFacultiesRepository _facultiesRepository;
        private readonly IUniversitiesRepository _universitiesRepository;
        private readonly IAddressesRepository _addressesRepository;
        private readonly IMapper _mapper;

        public FacultyService(IFacultiesRepository facultiesRepository, IAddressesRepository addressesRepository, IUniversitiesRepository universitiesRepository, IMapper mapper)
        {
            _facultiesRepository = facultiesRepository;
            _addressesRepository = addressesRepository;
            _universitiesRepository = universitiesRepository;
            _mapper = mapper;
        }

        public async Task<FacultyModel> GetByIdWithAddressStudentsAndUser(Guid facultyId)
        {
            var faculty = await _facultiesRepository.GetByIdWithAddressStudentsAndUser(facultyId);
            return _mapper.Map<FacultyModel>(faculty);
        }

        public async Task<FacultyModel> Add(CreateFacultyModel model)
        {
            var university = await _universitiesRepository.GetAllDependenciesById(model.UniversityId);
            var address = await _addressesRepository.GetById(model.AddressId);
            
            var faculty = _mapper.Map<Faculty>(model);
            faculty.UpdateAddress(address);

            university.AddFaculty(faculty);

            _universitiesRepository.Update(university);
            await _universitiesRepository.SaveAddedFaculty(faculty);

            return _mapper.Map<FacultyModel>(faculty);
        }

        public async Task Delete(Guid facultyId)
        {
            var faculty = await _facultiesRepository.GetAllDependenciesById(facultyId);

            _facultiesRepository.Delete(faculty);
            DeleteAllAdressesRefferedByFaculty(faculty);

            await _facultiesRepository.SaveChanges();
        }

        public async Task<IEnumerable<ListFacultyModel>> GetAllByUniversityId(Guid id)
        {
            var university = await _universitiesRepository.GetByIdWithFaculties(id);
            var faculties = new List<ListFacultyModel>();

            foreach(var faculty in university.Faculties)
            {
                faculties.Add(_mapper.Map<ListFacultyModel>(faculty));
            }
                                        
            return faculties;
        }

        public async Task Update(UpdateFacultyModel model)
        {
            var faculty = await _facultiesRepository.GetById(model.Id);

            faculty.Update(model.Name,model.PhoneNumber,model.PhoneNumber);
            _facultiesRepository.Update(faculty);
            await _facultiesRepository.SaveChanges();
        }
        private void DeleteAllAdressesRefferedByFaculty(Faculty faculty)
        {
            foreach (var student in faculty.Students)
            {
                _addressesRepository.Delete(student.Address);
            }
            _addressesRepository.Delete(faculty.Address);
        }
    }
}
