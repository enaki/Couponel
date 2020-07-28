using AutoMapper;
using Couponel.API.Extensions;
using Couponel.Business.Identities;
using Couponel.Business.Institutions;
using Couponel.Business.Institutions.Addresses.Services.Implementations;
using Couponel.Business.Institutions.Addresses.Services.Interfaces;
using Couponel.Business.Institutions.Faculties.Services.Implementations;
using Couponel.Business.Institutions.Faculties.Services.Interfaces;
using Couponel.Business.Institutions.Universities.Services.Implementations;
using Couponel.Business.Institutions.Universities.Services.Interfaces;
using Couponel.Persistence;
using Couponel.Persistence.IdentitiesRepositories.AdminsRepository;
using Couponel.Persistence.IdentitiesRepositories.OfferersRepository;
using Couponel.Persistence.IdentitiesRepositories.StudentsRepository;
using Couponel.Persistence.InstitutionsRepositories.AddressesRepository;
using Couponel.Persistence.InstitutionsRepositories.FacultiesRepository;
using Couponel.Persistence.InstitutionsRepositories.UniversitiesRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;

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
                .AddScoped<IFacultyService,FacultyService>()
                .AddScoped<IAddressService, AddressService>()
                .AddScoped<IUniversityService, UniversityService>()


                .AddScoped<IStudentsRepository, StudentsRepository>()
                .AddScoped<IAdminsRepository, AdminsRepository>()
                .AddScoped<IOfferorsRepository, OfferorsRepository>()
                .AddScoped<IAddressesRepository, AddressesRepository>()
                .AddScoped<IUniversitiesRepository, UniversitiesRepository>()
                .AddScoped<IFacultiesRepository, FacultiesRepository>();

            services
                .AddDbContext<CouponelContext>(config =>
                    config.UseSqlServer(Configuration.GetConnectionString("CouponelConnection")));
            
            services
                .AddAutoMapper(c =>
                {
                    c.AddProfile<InstitutionMappingProfile>();
                    c.AddProfile<IdentityMappingProfile>();
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
    }
}
