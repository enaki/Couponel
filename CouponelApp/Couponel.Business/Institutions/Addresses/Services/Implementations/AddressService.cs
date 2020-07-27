﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Institutions.Addresses.Models;
using Couponel.Business.Institutions.Addresses.Services.Interfaces;
using Couponel.Entities;
using Couponel.Persistence.AddressesRepository;

namespace Couponel.Business.Institutions.Addresses.Services.Implementations
{
    public sealed class AddressService: IAddressService
    {
        private readonly IAddressesRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddressModel> GetById(Guid addressId)
        {
            var address = await _repository.GetById(addressId);
            return _mapper.Map<AddressModel>(address);
        }

        public async Task<AddressModel> Add(CreateAddressModel model)
        {
            var address = _mapper.Map<Address>(model);

            await _repository.Add(address);
            await _repository.SaveChanges();

            return _mapper.Map<AddressModel>(address);
        }

        public async Task Delete(Guid addressId)
        {
            var address = await _repository.GetById(addressId);

            _repository.Delete(address);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var addresses = _repository.GetAll();
            return await (Task<IEnumerable<AddressModel>>)_mapper.Map<IEnumerable<AddressModel>>(addresses);
        }
    }
}