using Models.Infrastructure;

namespace Models.Business
{
    public class Course_User : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
