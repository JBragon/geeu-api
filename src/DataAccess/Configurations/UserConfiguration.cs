using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Business;

namespace DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(t => t.Registration)
                .HasColumnName("Registration")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("UpdatedAt")
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

            builder.HasMany(t => t.ExtensionProjectResponsible)
                .WithOne(t => t.ResponsibleUser)
                .HasForeignKey(t => t.ResponsibleUserId);

        }
    }
}
