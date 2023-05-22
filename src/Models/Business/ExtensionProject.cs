using Models.Enums;
using Models.Infrastructure;

namespace Models.Business
{
    public class ExtensionProject : BaseEntity<int>
    {
        public string Name { get; set; }
        public ExtensionProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProjects { get; set; }
        public virtual ICollection<Teacher_ExtensionProject> Teacher_ExtensionProjects { get; set; }
        public virtual ICollection<Student_ExtensionProject> Student_ExtensionProjects { get; set; }
        public virtual ICollection<ProjectStatusLog> ProjectStatusLogs { get; set; }
    }
}
