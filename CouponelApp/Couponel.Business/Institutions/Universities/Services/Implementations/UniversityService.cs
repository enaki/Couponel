using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Entities;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.InstitutionsRepositories.AddressesRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository;

namespace Couponel.Business.Institutions.Universities.Services.Implementations
{
    public sealed class UniversityService : IUniversityService
    {
        private readonly IUniversitiesRepository _univiersitiesRepository;
        private readonly IMapper _mapper;
        private readonly IAddressesRepository _addressesRepository;

        public UniversityService(IUniversitiesRepository univiersitiesRepository,IAddressesRepository addressesRepository, IMapper mapper)
        {
            _univiersitiesRepository = univiersitiesRepository;
            _addressesRepository = addressesRepository;
            _mapper = mapper;
        }

        public async Task<UniversityModel> GetByIdWithAddressAndFaculties(Guid universityId)
        {
            var university = await _univiersitiesRepository.GetByIdWithAddressFacultiesAndStudents(universityId);
            return _mapper.Map<UniversityModel>(university);
        }

        public async Task<UniversityModel> Add(CreateUniversityModel model)
        {
            var university = _mapper.Map<University>(model);

            await _univiersitiesRepository.Add(university);
            await _univiersitiesRepository.SaveChanges();

            return _mapper.Map<UniversityModel>(university);
        }

        public async Task Delete(Guid universityId)
        {
            var university = await _univiersitiesRepository.GetAllDependenciesById(universityId);
            
            _univiersitiesRepository.Delete(university);
            DeleteAllAdressesRefferedByUniversity(university);

            await _univiersitiesRepository.SaveChanges();
        }

        public async Task Update(Guid universityId, UpdateUniversityModel model)
        {
            var university = await _univiersitiesRepository.GetById(universityId);

            university.Update(model.Name, model.Email, model.PhoneNumber);

            _univiersitiesRepository.Update(university);
            await _univiersitiesRepository.SaveChanges();
        }
        public async Task<IEnumerable<ListUniversityModel>> GetAll()
        {
            var universities = await _univiersitiesRepository.GetAll();
            var mappedUniversities = new List<ListUniversityModel>();

            foreach (var university in universities)
            {
                if(university!=null)
                    mappedUniversities.Add(_mapper.Map<ListUniversityModel>(university));
            }
            return mappedUniversities;
        }

        private void DeleteAllAdressesRefferedByUniversity(University university) {
            foreach (var faculty in university.Faculties)
            {
                foreach (var student in faculty.Students)
                {
                    if (student.Address != null)
                        _addressesRepository.Delete(student.Address);
                }
                _addressesRepository.Delete(faculty.Address);
            }
            _addressesRepository.Delete(university.Address);
        }
    }
}
