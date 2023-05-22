using Models.Infrastructure;

namespace Models.Business
{
    public class Teacher_ExtensionProject : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int ExtensionProjectId { get; set; }

        public virtual User User { get; set; }
        public virtual ExtensionProject ExtensionProject { get; set; }
    }
}
