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
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.Course_Users, opt => opt.Ignore())
                .ForMember(c => c.Course_ExtensionProjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CourseResponse, Course>()
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.Course_Users, opt => opt.Ignore())
                .ForMember(c => c.Course_ExtensionProjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ExtensionProjectPost, ExtensionProject>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Status, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.Reports, opt => opt.Ignore())
                .ForMember(c => c.Student_ExtensionProjects, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProjectStatusLogs, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ExtensionProjectResponse, ExtensionProject>()
                .ReverseMap();

            CreateMap<ReportPost, Report>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProject, opt => opt.Ignore())
                .ForMember(c => c.User, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ReportResponse, Report>()
                .ForMember(c => c.ExtensionProject, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Course_ExtensionProjectPost, Course_ExtensionProject>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProjectId, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProject, opt => opt.Ignore())
                .ForMember(c => c.Course, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Teacher_ExtensionProjectPost, Teacher_ExtensionProject>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore())
                .ForMember(c => c.CreatedBy, opt => opt.Ignore())
                .ForMember(c => c.UpdatedBy, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProjectId, opt => opt.Ignore())
                .ForMember(c => c.ExtensionProject, opt => opt.Ignore())
                .ForMember(c => c.User, opt => opt.Ignore())
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
