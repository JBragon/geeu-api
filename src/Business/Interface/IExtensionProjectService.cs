using Models.Filters;
using Models.Infrastructure;

namespace Business.Interface
{
    public interface IExtensionProjectService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(ExtensionProjectFilter filter);
    }
}
