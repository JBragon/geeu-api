using Models.Enums;
using Models.Infrastructure;

namespace Models.Business
{
    public class Report : BaseEntity<int>
    {
        public int ExtensionProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual ExtensionProject ExtensionProject { get; set; }
    }
}
