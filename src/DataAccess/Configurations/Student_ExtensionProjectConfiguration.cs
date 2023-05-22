using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class Student_ExtensionProjectConfiguration : IEntityTypeConfiguration<Student_ExtensionProject>
    {
        public void Configure(EntityTypeBuilder<Student_ExtensionProject> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Student_ExtensionProject");

            // Primary Key
            builder.HasKey(t => new {t.ExtensionProjectId, t.UserId});

            builder.Ignore(t => t.Id);
            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.Student_ExtensionProjects)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasOne(t => t.User)
                .WithMany(t => t.Student_ExtensionProjects)
                .HasForeignKey(t => t.UserId);

        }
    }
}
