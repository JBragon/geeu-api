using Models.Business;

namespace Models.Mapper.Response
{
    public class ReportResponse
    {
        public int Id { get; set; }
        public int ExtensionProjectId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual User User { get; set; }
    }
}
