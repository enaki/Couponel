using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Universities.Models;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Entities;
using Couponel.Persistence.UniversitiesRepository;

namespace Couponel.Business.Institutions.Universities.Services.Implementations
{
    public sealed class UniversityService: IUniversityService
    {
        private readonly IUniversitiesRepository _repository;
        private readonly IMapper _mapper;

        public UniversityService(IUniversitiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UniversityModel> GetById(Guid universityId)
        {
            var university = await _repository.GetById(universityId);
            return _mapper.Map<UniversityModel>(university);
        }

        public async Task<UniversityModel> Add(CreateUniversityModel model)
        {
            var university = _mapper.Map<University>(model);

            await _repository.Add(university);
            await _repository.SaveChanges();

            return _mapper.Map<UniversityModel>(university);
        }

        public async Task Delete(Guid universityId)
        {
            var university = await _repository.GetByIdWithAddressAndFaculties(universityId);
            _repository.Delete(university);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<UniversityModel>> GetAll()
        {
            var universities = _repository.GetAll();
            return await (Task<IEnumerable<UniversityModel>>)_mapper.Map<IEnumerable<UniversityModel>>(universities);
        }
    }
}
