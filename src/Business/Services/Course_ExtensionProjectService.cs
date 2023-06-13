using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class Course_ExtensionProjectService : BaseService<Course_ExtensionProject, int>, ICourse_ExtensionProjectService
    {
        public Course_ExtensionProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
