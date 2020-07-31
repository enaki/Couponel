using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Identities.Offerers.Models;
using Couponel.Business.Identities.Offerers.Services.Interfaces;
using Couponel.Entities.Identities.UserTypes;
using Couponel.Entities.Institutions;
using Couponel.Persistence.Repositories.IdentitiesRepositories.OfferersRepository;


namespace Couponel.Business.Identities.Offerers.Services.Implementations
{
    public sealed class OffererService: IOffererService
    {
        private readonly IOfferorsRepository _repository;
        private readonly IMapper _mapper;

        public OffererService(IOfferorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OffererModel> GetById(Guid addressId)
        {
            var address = await _repository.GetById(addressId);
            return _mapper.Map<OffererModel>(address);
        }

        public async Task<OffererModel> Add(CreateOffererModel model)
        {
            var address = _mapper.Map<Offerer>(model);

            await _repository.Add(address);
            await _repository.SaveChanges();

            return _mapper.Map<OffererModel>(address);
        }

        public async Task Delete(Guid addressId)
        {
            var address = await _repository.GetById(addressId);

            _repository.Delete(address);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<OffererModel>> GetAll()
        {
            var addresses = _repository.GetAll();
            return await (Task<IEnumerable<OffererModel>>)_mapper.Map<IEnumerable<OffererModel>>(addresses);
        }
    }
}
