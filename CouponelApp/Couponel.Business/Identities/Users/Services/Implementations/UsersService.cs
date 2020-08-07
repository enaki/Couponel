using AutoMapper;
using Couponel.Business.Identities.Users.Models;
using Couponel.Business.Identities.Users.Services.Interfaces;
using Couponel.Entities.Identities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Couponel.Business.Authentications.Services.Interfaces;
using Couponel.Business.Identities.Students.Models;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Persistence.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Identities.Users.Services.Implementations
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _repository;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IHttpContextAccessor _accessor;

        public UsersService(IUsersRepository repository,IStudentService studentService, IPasswordHasher passwordHasher, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
            _passwordHasher = passwordHasher;
            _studentService = studentService;
        }

        public async Task Update(UpdateUserModel model)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var passwordHash = _passwordHasher.CreateHash(model.Password);

            var user = await _repository.GetById(userId);
            user.Update(model.Email, passwordHash, model.FirstName, model.LastName, model.PhoneNumber, model.Address);
            _repository.Update(user);
            await _repository.SaveChanges();
        }
        public async Task<IUserDetailsModel> GetDetailsById(Guid id)
        {
            var user = await _repository.GetById(id);
            var userDetails = _mapper.Map<UserDetailsModel>(user);

            if (user.Role != Role.Student) return userDetails;

            var institutionsDetails = await _studentService.GetStudentDetailsById(id);
            var studentDetails = _mapper.Map<StudentDetailsModel>(userDetails);
            studentDetails.FacultyName = institutionsDetails.FacultyName;
            studentDetails.UniversityName = institutionsDetails.UniversityName;

            return studentDetails;
        }
    }
}
