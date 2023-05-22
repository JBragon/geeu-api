using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class ExtensionProjectService : BaseService<ExtensionProject, int>, IExtensionProjectService
    {
        public ExtensionProjectService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
