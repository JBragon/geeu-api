using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class Course_ExtensionProjectConfiguration : IEntityTypeConfiguration<Course_ExtensionProject>
    {
        public void Configure(EntityTypeBuilder<Course_ExtensionProject> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Course_ExtensionProject");

            // Primary Key
            builder.HasKey(t => new {t.ExtensionProjectId, t.CourseId});

            builder.Ignore(t => t.Id);
            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.Course_ExtensionProjects)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasOne(t => t.Course)
                .WithMany(t => t.Course_ExtensionProjects)
                .HasForeignKey(t => t.CourseId);

        }
    }
}
