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
        public virtual ICollection<Course_ExtensionProject> Course_ExtensionProject { get; set; }
        public virtual ICollection<ProjectStatusLog> ProjectStatusLog { get; set; }
    }
}
