using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CouponelServices.Business.Institutions.Universities.Models;
using CouponelServices.Business.Institutions.Universities.Services.Interfaces;
using CouponelServices.Entities;
using CouponelServices.Persistence.UniversitiesRepository;

namespace CouponelServices.Business.Institutions.Universities.Services.Implementations
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
            var university = await _repository.GetById(universityId);

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
