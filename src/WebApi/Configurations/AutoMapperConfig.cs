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
            CreateMap<CoursePost, Course>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.Course_Users, opt => opt.Ignore())
                .ForMember(c => c.Course_ExtensionProjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CourseResponse, Course>()
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.Course_Users, opt => opt.Ignore())
                .ForMember(c => c.Course_ExtensionProjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ExtensionProjectPost, ExtensionProject>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.Reports, opt => opt.Ignore())
                .ForMember(c => c.Course_ExtensionProjects, opt => opt.Ignore())
                .ForMember(c => c.Teacher_ExtensionProjects, opt => opt.Ignore())
                .ForMember(c => c.Student_ExtensionProjects, opt => opt.Ignore())
                .ForMember(c => c.ProjectStatusLogs, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ExtensionProjectResponse, ExtensionProject>()
                .ReverseMap();
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
