using AutoMapper;
using Couponel.API.Extensions;
using CouponelServices.Business.Institutions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CouponelServices.Persistence;
using Microsoft.EntityFrameworkCore;
using CouponelServices.Persistence.Repository;
using CouponelServices.Persistence.StudentsRepository;
using CouponelServices.Persistence.AddressesRepository;
using CouponelServices.Persistence.FacultiesRepository;
using CouponelServices.Persistence.UniversitiesRepository;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using CouponelServices.Business.Institutions.Faculties.Services.Interfaces;
using CouponelServices.Business.Institutions.Faculties.Services.Implementations;
using CouponelServices.Business.Institutions.Addresses.Services.Implementations;
using CouponelServices.Business.Institutions.Addresses.Services.Interfaces;
using CouponelServices.Business.Institutions.Universities.Services.Interfaces;
using CouponelServices.Business.Institutions.Universities.Services.Implementations;

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
