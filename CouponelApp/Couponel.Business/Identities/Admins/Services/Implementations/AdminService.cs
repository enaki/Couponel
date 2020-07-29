using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Identities.Admins.Models;
using Couponel.Business.Identities.Admins.Services.Interfaces;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Persistence.Repositories.IdentitiesRepositories.AdminsRepository;

namespace Couponel.Business.Identities.Admins.Services.Implementations
{
    public sealed class AdminService: IAdminService
    {
        private readonly IAdminsRepository _repository;
        private readonly IMapper _mapper;

        public AdminService(IAdminsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdminModel> GetById(Guid adminId)
        {
            var admin = await _repository.GetById(adminId);
            return _mapper.Map<AdminModel>(admin);
        }

        public async Task<AdminModel> Add(CreateAdminModel model)
        {
            var admin = _mapper.Map<Admin>(model);

            await _repository.Add(admin);
            await _repository.SaveChanges();

            return _mapper.Map<AdminModel>(admin);
        }

        public async Task Delete(Guid adminId)
        {
            var admin = await _repository.GetById(adminId);

            _repository.Delete(admin);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<AdminModel>> GetAll()
        {
            var admins = _repository.GetAll();
            return await (Task<IEnumerable<AdminModel>>)_mapper.Map<IEnumerable<AdminModel>>(admins);
        }
    }
}
