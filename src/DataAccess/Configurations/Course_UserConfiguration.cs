using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class Course_UserConfiguration : IEntityTypeConfiguration<Course_User>
    {
        public void Configure(EntityTypeBuilder<Course_User> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Course_User");

            // Primary Key
            builder.HasKey(t => new {t.UserId, t.CourseId});

            builder.Ignore(t => t.Id);
            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.User)
                .WithMany(t => t.Course_Users)
                .HasForeignKey(t => t.UserId);

            builder.HasOne(t => t.Course)
                .WithMany(t => t.Course_Users)
                .HasForeignKey(t => t.CourseId);

        }
    }
}
