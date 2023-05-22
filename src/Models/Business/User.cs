using Models.Infrastructure;

namespace Models.Business
{
    public class User : BaseEntity<int>
    {
        public string Registration { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Teacher_ExtensionProject> Teacher_ExtensionProjects { get; set; }
        public virtual ICollection<Student_ExtensionProject> Student_ExtensionProjects { get; set; }
        public virtual ICollection<Course_User> Course_Users { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
