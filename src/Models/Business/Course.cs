using Models.Infrastructure;

namespace Models.Business
{
    public class Course : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProjects { get; set; }
        public virtual ICollection<Course_User> Course_Users { get; set; }
    }
}
