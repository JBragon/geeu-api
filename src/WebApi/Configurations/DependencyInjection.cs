﻿using Business.Interface;
using Business.Services;
using FluentValidation;
using IdentityServer4.Stores;
using Models.Mapper.Request;

namespace WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IExtensionProjectService, ExtensionProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IClientStore, ClientStoreImplementation>();

            //Fluent Validation
            services.AddTransient<IValidator<CoursePost>, CoursePostValidation>();
            services.AddTransient<IValidator<ExtensionProjectPost>, ExtensionProjectPostValidation>();

            return services;
        }
    }
}
