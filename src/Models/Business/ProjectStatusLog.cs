using Models.Enums;
using Models.Infrastructure;

namespace Models.Business
{
    public class ProjectStatusLog : BaseEntity<int>
    {
        public int ExtensionProjectId { get; set; }
        public ExtensionProjectStatus Status { get; set; }

        public virtual ExtensionProject ExtensionProject { get; set; }
    }
}
