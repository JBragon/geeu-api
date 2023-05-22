using Models.Enums;
using Models.Infrastructure;

namespace Models.Business
{
    public class Student_ExtensionProject : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int ExtensionProjectId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Workload { get; set; }
        public ParticipationStatus Stats { get; set; }

        public virtual User User { get; set; }
        public virtual ExtensionProject ExtensionProject { get; set; }
    }
}
