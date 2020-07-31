using AutoMapper;
using Couponel.API.Extensions;
using Couponel.Business.Authentications;
using Couponel.Business.Authentications.Services.Implementations;
using Couponel.Business.Authentications.Services.Interfaces;
using Couponel.Business.Coupons;
using Couponel.Business.Coupons.Comments.Services.Implementations;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Couponel.Business.Coupons.Coupons.Services.Implementations;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Couponel.Business.Identities;
using Couponel.Business.Identities.Admins.Services.Implementations;
using Couponel.Business.Identities.Admins.Services.Interfaces;
using Couponel.Business.Identities.Offerers.Services.Implementations;
using Couponel.Business.Identities.Offerers.Services.Interfaces;
using Couponel.Business.Identities.Students.Services.Implementations;
using Couponel.Business.Identities.Students.Services.Interfaces;
using Couponel.Business.Institutions;
using Couponel.Business.Institutions.Addresses.Services.Implementations;
using Couponel.Business.Institutions.Addresses.Services.Interfaces;
using Couponel.Business.Institutions.Faculties.Services.Implementations;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Business.Institutions.Universities.Services.Implementations;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Persistence;
using Couponel.Persistence.Repositories.CouponsRepositories.CommentsRepository;
using Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository;
using Couponel.Persistence.Repositories.IdentitiesRepositories.AdminsRepository;
using Couponel.Persistence.Repositories.IdentitiesRepositories.OfferersRepository;
using Couponel.Persistence.Repositories.IdentitiesRepositories.StudentsRepository;
using Couponel.Persistence.Repositories.IdentitiesRepositories.UsersRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.AddressesRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.FacultiesRepository;
using Couponel.Persistence.Repositories.InstitutionsRepositories.UniversitiesRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Couponel.Business.Authentications.Models;

namespace Couponel.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services
                .AddScoped<IFacultyService, FacultyService>()
                .AddScoped<IAddressService, AddressService>()
                .AddScoped<IUniversityService, UniversityService>()
                .AddScoped<ICouponService, CouponService>()
                .AddScoped<ICommentsService, CommentsService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<IOffererService, OffererService>()
                .AddScoped<IAdminService, AdminService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()

                .AddScoped<IPasswordHasher, PasswordHasher>()

                .AddScoped<IStudentsRepository, StudentsRepository>()
                .AddScoped<IAdminsRepository, AdminsRepository>()
                .AddScoped<IOfferersRepository, OfferersRepository>()
                .AddScoped<IUsersRepository, UsersRepository>()
                .AddScoped<ICouponsRepository, CouponsRepository>()
                .AddScoped<ICommentsRepository, CommentsRepository>()
                .AddScoped<IAddressesRepository, AddressesRepository>()
                .AddScoped<IUniversitiesRepository, UniversitiesRepository>()
                .AddScoped<IFacultiesRepository, FacultiesRepository>();

            AddAuthentication(services);

            services
                .AddDbContext<CouponelContext>(config =>
                    config.UseSqlServer(Configuration.GetConnectionString("CouponelConnection")));

            services
                .AddAutoMapper(c =>
                {
                    c.AddProfile<InstitutionMappingProfile>();
                    c.AddProfile<IdentityMappingProfile>();
                    c.AddProfile<CouponMappingProfile>();
                    c.AddProfile<AuthenticationMappingProfile>();
                })
                .AddHttpContextAccessor()
                .AddSwagger()
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);





            services
                .AddMvc()
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Couponel API"));

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
        private void AddAuthentication(IServiceCollection services)
        {
            var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience
                    };
                });
        }
    }
}
