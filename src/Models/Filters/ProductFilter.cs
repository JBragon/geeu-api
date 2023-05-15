using LinqKit;
using Models.Business;
using System.Linq.Expressions;

namespace Models.Filters
{
    //public class ProductFilter : Filter
    //{
    //    public string? Name { get; set; }

    //    private Expression<Func<Product, bool>> filter = PredicateBuilder.New<Product>(true);
    //    private Func<IQueryable<Product>, IOrderedQueryable<Product>> order;

    //    public Expression<Func<Product, bool>> GetFilter()
    //    {
    //        if (!string.IsNullOrWhiteSpace(Name))
    //            filter = filter.And(x => x.Name == Name);

    //        return filter;
    //    }

    //}
}
