using Models.Filters;
using Models.Infrastructure;
using Models.Mapper.Request;

namespace Business.Interface
{
    public interface IExtensionProjectService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(ExtensionProjectFilter filter);
        SearchResponse<TOutputModel> GetExtensionProjectPendingApproval<TOutputModel>(GetExtensionProjectPendingApproval rows);
    }
}
