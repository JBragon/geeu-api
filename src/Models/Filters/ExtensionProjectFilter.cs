using LinqKit;
using Models.Business;
using Models.Enums;
using System.Linq.Expressions;

namespace Models.Filters
{
    public class ExtensionProjectFilter : Filter
    {
        public string? Name { get; set; }
        public ExtensionProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Expression<Func<ExtensionProject, bool>> filter = PredicateBuilder.New<ExtensionProject>(true);
        private Func<IQueryable<ExtensionProject>, IOrderedQueryable<ExtensionProject>> order;

        public Expression<Func<ExtensionProject, bool>> GetFilter()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                filter = filter.And(x => x.Name == Name);

            if (Status != null)
                filter = filter.And(x => x.Status == Status);

            if (StartDate != null && EndDate == null)
            {
                filter = filter.And(x => x.StartDate == StartDate);
            }
            else if (StartDate == null && EndDate != null)
            {
                filter = filter.And(x => x.EndDate == EndDate);
            }
            else
            {
                filter = filter.And(x => x.StartDate >= StartDate
                                        && x.EndDate <= EndDate);
            }

            return filter;
        }

    }
}
