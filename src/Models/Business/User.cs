using Microsoft.AspNetCore.Identity;

namespace Models.Business
{
    public class User : IdentityUser<int>
    {
        public string Registration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Teacher_ExtensionProject> Teacher_ExtensionProjects { get; set; }
        public virtual ICollection<Student_ExtensionProject> Student_ExtensionProjects { get; set; }
        public virtual ICollection<Course_User> Course_Users { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<ExtensionProject> ExtensionProjectResponsible { get; set; }
    }
}
