using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class ProjectStatusLogConfiguration : IEntityTypeConfiguration<ProjectStatusLog>
    {
        public void Configure(EntityTypeBuilder<ProjectStatusLog> builder)
        {
            // Table & Column Mappings
            builder.ToTable("ProjectStatusLog");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.ExtensionProjectId)
                .HasColumnName("ExtensionProjectId")
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.ProjectStatusLog)
                .HasForeignKey(t => t.ExtensionProjectId);

        }
    }
}
