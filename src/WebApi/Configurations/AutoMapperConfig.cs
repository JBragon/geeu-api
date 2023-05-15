using AutoMapper;
using Models.Business;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductResponse, Product>()
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.EngelsCurves, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(d => d.EngelsCurvesResponse, opt => opt.MapFrom(s => s.EngelsCurves));

            CreateMap<EngelsCurveResponse, EngelsCurve>()
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.Product, opt => opt.Ignore())
                .ForMember(c => c.ProductId, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProductPost, Product>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.EngelsCurves, opt => opt.Ignore())
                .ForMember(c => c.Observation, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(d => d.EngelsCurvesPost, opt => opt.MapFrom(s => s.EngelsCurves));
        }
    }

    public static class AutoMapperExtension
    {
        /// <summary>
        /// Registrar AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            mappingConfig.AssertConfigurationIsValid();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
