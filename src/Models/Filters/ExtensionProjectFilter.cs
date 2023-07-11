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
        public List<int> ListCourseId { get; set; }

        private Expression<Func<ExtensionProject, bool>> filter = PredicateBuilder.New<ExtensionProject>(true);
        private Func<IQueryable<ExtensionProject>, IOrderedQueryable<ExtensionProject>> order;

        public Expression<Func<ExtensionProject, bool>> GetFilter()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                filter = filter.And(x => x.Name == Name);

            if (Status != null)
                filter = filter.And(x => x.Status == Status);

            if (StartDate != DateTime.MinValue && EndDate == DateTime.MinValue)
            {
                filter = filter.And(x => x.StartDate == StartDate);
            }
            else if (StartDate == DateTime.MinValue && EndDate != DateTime.MinValue)
            {
                filter = filter.And(x => x.EndDate == EndDate);
            }
            else if (StartDate != DateTime.MinValue && EndDate != DateTime.MinValue)
            {
                filter = filter.And(x => x.StartDate >= StartDate
                                        && x.EndDate <= EndDate);
            }

            if (ListCourseId is not null && ListCourseId.Any())
            {
                filter = filter.And(x => x.Course_ExtensionProjects.Any(c => ListCourseId.Contains(c.CourseId)));
            }

            return filter;
        }

    }
}
