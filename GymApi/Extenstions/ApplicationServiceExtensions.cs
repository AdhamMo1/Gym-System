using GymApi.Helpers;
using GymCore.Entities;
using GymCore.Interfaces;
using GymCore.Interfaces.IUnitOfWorkConfig;
using GymInfrastructure.Data;
using GymInfrastructure.Data.Repo;
using GymInfrastructure.Data.UnitOfWorkConfig;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Formatting.Json;

namespace GymApi.Extenstions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Inject IUnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Configure DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            // Configure AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddLogging();
            // add Authentication
            services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            // add Authorization
            services.AddAuthorizationBuilder();
            // add Identity
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();
            services.TryAddTransient<IEmailSender, NoOpEmailSender>();
            // Configure Serilog 
            services.AddSerilog((context, loggerConfig) => {
                loggerConfig.WriteTo.Console();
                loggerConfig.WriteTo.File(new JsonFormatter(), "logs/applogs-.txt", rollingInterval:RollingInterval.Day);
            });

            return services;
        }
    }
}
