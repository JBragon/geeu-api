using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class ExtensionProjectStatusLogService : BaseService<ExtensionProjectStatusLog, int>, IExtensionProjectStatusLogService
    {
        public ExtensionProjectStatusLogService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
