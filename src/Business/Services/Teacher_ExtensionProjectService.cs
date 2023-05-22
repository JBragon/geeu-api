using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class Teacher_ExtensionProjectService : BaseService<Teacher_ExtensionProject, int>, ITeacher_ExtensionProjectService
    {
        public Teacher_ExtensionProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
