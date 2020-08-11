using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.UniversitiesRepository;

namespace Couponel.Business.Institutions.Universities.Services.Implementations
{
    public sealed class UniversityService : IUniversityService
    {
        private readonly IUniversitiesRepository _universitiesRepository;
        private readonly IMapper _mapper;

        public UniversityService(IUniversitiesRepository universitiesRepository, IMapper mapper)
        {
            _universitiesRepository = universitiesRepository;
            _mapper = mapper;
        }

        public async Task<UniversityModel> GetByIdWithAddressAndFaculties(Guid universityId)
        {
            var university = await _universitiesRepository.GetByIdWithAddressFacultiesAndStudents(universityId);
            return _mapper.Map<UniversityModel>(university);
        }

        public async Task<UniversityModel> Add(CreateUniversityModel model)
        {
            var university = _mapper.Map<University>(model);

            await _universitiesRepository.Add(university);
            await _universitiesRepository.SaveChanges();

            return _mapper.Map<UniversityModel>(university);
        }

        public async Task Delete(Guid universityId)
        {
            var university = await _universitiesRepository.GetAllDependenciesById(universityId);
            
            _universitiesRepository.Delete(university);

            await _universitiesRepository.SaveChanges();
        }

        public async Task Update(Guid universityId, UpdateUniversityModel model)
        {
            var university = await _universitiesRepository.GetById(universityId);
            university.Update(model.Name, model.Email, model.PhoneNumber, model.Address);

            _universitiesRepository.Update(university);
            await _universitiesRepository.SaveChanges();
        }
        public async Task<IEnumerable<ListUniversityModel>> GetAll()
        {
            var universities = await _universitiesRepository.GetAllWithFaculties();
            return (from university in universities where university != null select _mapper.Map<ListUniversityModel>(university)).ToList();
        }
    }
}
