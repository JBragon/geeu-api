using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table & Column Mappings
            builder.ToTable("Course");

            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore(t => t.CreatedAt);
            builder.Ignore(t => t.UpdatedAt);

            builder.HasMany(t => t.Course_ExtensionProjects)
                .WithOne(t => t.Course);

            builder.HasMany(t => t.Course_Users)
                .WithOne(t => t.Course);
        }
    }
}
