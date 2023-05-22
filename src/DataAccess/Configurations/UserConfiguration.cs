using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table & Column Mappings
            builder.ToTable("User");

            // Primary Key
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Registration)
                .HasColumnName("Registration")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(t => t.Teacher_ExtensionProjects)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder.HasMany(t => t.Student_ExtensionProjects)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder.HasMany(t => t.Course_Users)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder.HasMany(t => t.Reports)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

        }
    }
}
