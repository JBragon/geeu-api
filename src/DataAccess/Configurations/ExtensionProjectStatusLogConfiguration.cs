using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class ExtensionProjectStatusLogConfiguration : IEntityTypeConfiguration<ExtensionProjectStatusLog>
    {
        public void Configure(EntityTypeBuilder<ExtensionProjectStatusLog> builder)
        {
            // Table & Column Mappings
            builder.ToTable("ExtensionProjectStatusLog");

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

            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired();

            builder.Ignore(t => t.UpdatedAt);
            builder.Ignore(t => t.UpdatedBy);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.ExtensionProjectStatusLogs)
                .HasForeignKey(t => t.ExtensionProjectId);

        }
    }
}
