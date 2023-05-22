using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class Teacher_ExtensionProjectConfiguration : IEntityTypeConfiguration<Teacher_ExtensionProject>
    {
        public void Configure(EntityTypeBuilder<Teacher_ExtensionProject> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Teacher_ExtensionProject");

            // Primary Key
            builder.HasKey(t => new {t.ExtensionProjectId, t.UserId});

            builder.Ignore(t => t.Id);
            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.Teacher_ExtensionProjects)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasOne(t => t.User)
                .WithMany(t => t.Teacher_ExtensionProjects)
                .HasForeignKey(t => t.UserId);

        }
    }
}
