using Models.Business;
using Models.Enums;

namespace Models.Mapper.Response
{
    public class ExtensionProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExtensionProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProjects { get; set; }
        public virtual ICollection<Teacher_ExtensionProject> Teacher_ExtensionProjects { get; set; }
        public virtual ICollection<Student_ExtensionProject> Student_ExtensionProjects { get; set; }
        public virtual ICollection<ProjectStatusLog> ProjectStatusLogs { get; set; }
    }
}
