using Models.Filters;
using Models.Infrastructure;

namespace Business.Interface
{
    public interface IReportService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(ReportFilter filter);
    }
}
