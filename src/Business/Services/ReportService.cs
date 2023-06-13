using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Business.Interface;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.Business;
using Models.Filters;
using Models.Infrastructure;

namespace Business.Services
{
    public class ReportService : BaseService<Report, int>, IReportService
    {
        public ReportService(IUnitOfWork<DBContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(ReportFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: source => source.Include(t => t.User),
               orderBy: null,
               filter.Page,
               filter.RowsPerPage
            );

            return response;
        }
    }
}
