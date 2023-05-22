using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Report");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.ExtensionProjectId)
                .HasColumnName("ExtensionProjectId")
                .IsRequired();

            builder.Property(t => t.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.ExtensionProject)
                .WithMany(t => t.Reports)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasOne(t => t.User)
                .WithMany(t => t.Reports)
                .HasForeignKey(t => t.UserId);
        }
    }
}
