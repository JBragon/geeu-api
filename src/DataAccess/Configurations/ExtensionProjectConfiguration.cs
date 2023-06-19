using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class ExtensionProjectConfiguration : IEntityTypeConfiguration<ExtensionProject>
    {
        public void Configure(EntityTypeBuilder<ExtensionProject> builder)
        {
            // Table & Column Mappings
            builder.ToTable("ExtensionProject");

            // Primary Key
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.ResponsibleUserId)
                .HasColumnName("ResponsibleUser")
                .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(t => t.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.EndDate)
                .HasColumnName("EndDate");

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasMany(t => t.Course_ExtensionProjects)
                .WithOne(t => t.ExtensionProject)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasMany(t => t.ExtensionProjectStatusLogs)
                .WithOne(t => t.ExtensionProject)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasMany(t => t.Teacher_ExtensionProjects)
                .WithOne(t => t.ExtensionProject)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasMany(t => t.Student_ExtensionProjects)
                .WithOne(t => t.ExtensionProject)
                .HasForeignKey(t => t.ExtensionProjectId);

            builder.HasOne(t => t.ResponsibleUser)
                .WithMany(t => t.ExtensionProjectResponsible)
                .HasForeignKey(t => t.ResponsibleUserId);
        }
    }
}
