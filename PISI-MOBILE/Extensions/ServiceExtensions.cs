using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PISI.Application.Services.Service;
using PISI.Application.Services.Subscription;
using PISI.Application.Services.TokenService;
using PISI.Application.Validators;
using PISI.Domain.Interfaces.IRepository;
using PISI.Domain.Interfaces.Service;
using PISI.Domain.Interfaces.Subscription;
using PISI.Domain.Interfaces.Token;
using PISI.Domain.Models.Service;
using PISI.Infrastructure.Context;
using PISI.Infrastructure.Repositories.Service;
using PISI.Infrastructure.Repositories.Subcription;

namespace PISI_MOBILE.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<PISIDbContext>(opts => opts.UseMySQL(configuration.GetConnectionString("DbConfig")));
        public static void ConfigureSubscribeRepo(this IServiceCollection services) =>
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
        public static void ConfigureServiceRepo(this IServiceCollection services) =>
        services.AddScoped<IServiceRepository, ServiceRepository>();
        public static void ConfigureTokenService(this IServiceCollection services) =>
        services.AddScoped<ITokenService, TokenService>();
        public static void ConfigureSubscribeService(this IServiceCollection services) =>
            services.AddScoped<ISubscription, SubscriptionService>();
        public static void ConfigureService(this IServiceCollection services) =>
        services.AddScoped<IService, Service>();

        public static void ConfigureHttpContext(this IServiceCollection services) =>
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        public static IApplicationBuilder UseJwtConfiguration(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }

        public static void ConfigureSubscribeValidator(this IServiceCollection services) =>
            services.AddValidatorsFromAssemblyContaining<SubscribeValidator>(ServiceLifetime.Transient);
        public static void ConfigureLoginValidator(this IServiceCollection services) =>
        services.AddValidatorsFromAssemblyContaining<LogInValidator>(ServiceLifetime.Transient);

        public static void ConfigureSwaggerGen(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PISI-Assessment.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                        new string[]{}
                    }
                });
            });
    }
}
