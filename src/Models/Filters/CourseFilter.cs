using LinqKit;
using Models.Business;
using System.Linq.Expressions;

namespace Models.Filters
{
    public class CourseFilter : Filter
    {
        public string? Name { get; set; }

        private Expression<Func<Course, bool>> filter = PredicateBuilder.New<Course>(true);
        private Func<IQueryable<Course>, IOrderedQueryable<Course>> order;

        public Expression<Func<Course, bool>> GetFilter()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                filter = filter.And(x => x.Name == Name);

            return filter;
        }

    }
}
