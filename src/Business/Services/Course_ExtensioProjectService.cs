using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class Course_ExtensioProjectService : BaseService<Course_ExtensionProject, int>, ICourse_ExtensioProjectService
    {
        public Course_ExtensioProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
