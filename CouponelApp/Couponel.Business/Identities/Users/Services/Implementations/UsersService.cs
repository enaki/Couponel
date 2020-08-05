using AutoMapper;
using Couponel.Business.Identities.Users.Models;
using Couponel.Business.Identities.Users.Services.Interfaces;
using Couponel.Entities.Identities;
using Couponel.Persistence.Repositories.IdentitiesRepositories.UsersRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Couponel.Business.Authentications.Services.Interfaces;

namespace Couponel.Business.Identities.Users.Services.Implementations
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public UsersService(IUsersRepository repository,IPasswordHasher passwordHasher, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task Update(UpdateUserModel model)
        {
            var passwordHash = _passwordHasher.CreateHash(model.Password);
            var user = await _repository.GetById(model.Id);
            user.Update(model.Email, passwordHash, model.FirstName, model.LastName, model.PhoneNumber, model.Address);
            _repository.Update(user);
            await _repository.SaveChanges();
        }


    }
}
