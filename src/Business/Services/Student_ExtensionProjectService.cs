using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class Student_ExtensionProjectService : BaseService<Student_ExtensionProject, int>, IStudent_ExtensionProjectService
    {
        public Student_ExtensionProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
