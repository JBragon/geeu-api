using Models.Filters;
using Models.Infrastructure;

namespace Business.Interface
{
    public interface ICourseService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(CourseFilter filter);
    }
}
