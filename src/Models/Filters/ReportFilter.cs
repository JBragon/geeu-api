using LinqKit;
using Models.Business;
using System.Linq.Expressions;

namespace Models.Filters
{
    public class ReportFilter : Filter
    {
        public int ExtensionProjectId { get; set; }
        public int UserId { get; set; }

        private Expression<Func<Report, bool>> filter = PredicateBuilder.New<Report>(true);
        private Func<IQueryable<Report>, IOrderedQueryable<Report>> order;

        public Expression<Func<Report, bool>> GetFilter()
        {
            if (ExtensionProjectId != null)
                filter = filter.And(x => x.ExtensionProjectId.Equals(ExtensionProjectId));

            if (UserId != null)
                filter = filter.And(x => x.UserId.Equals(UserId));

            return filter;
        }

    }
}
