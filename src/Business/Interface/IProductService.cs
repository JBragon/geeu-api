using Models.Filters;
using Models.Infrastructure;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace Business.Interface
{
    public interface IProductService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(ProductFilter filter);
        ProductResponse InsertAndClassificateProduct(ProductPost inputProduct);
    }
}
