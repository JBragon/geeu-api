using Business.Interface;
using Business.Services;
using FluentValidation;
using Models.Mapper.Request;

namespace WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEngelsCurveService, EngelsCurveService>();

            //Fluent Validation
            services.AddTransient<IValidator<ProductPost>,  ProductPostValidation>();

            return services;
        }
    }
}
