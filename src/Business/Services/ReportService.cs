using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Models.Business;

namespace Business.Services
{
    public class ReportService : BaseService<Report, int>, IReportService
    {
        public ReportService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
