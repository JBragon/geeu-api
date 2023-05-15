using Models.Infrastructure;

namespace Models.Business
{
    public class Course : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProject { get; set; }
    }
}
