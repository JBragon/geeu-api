﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Business.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Models.Business.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Models.Business.Course_ExtensionProject", b =>
                {
                    b.Property<int>("ExtensionProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasKey("ExtensionProjectId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Course_ExtensionProject", (string)null);
                });

            modelBuilder.Entity("Models.Business.Course_User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Course_User", (string)null);
                });

            modelBuilder.Entity("Models.Business.ExtensionProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("Name");

                    b.Property<int>("ResponsibleUserId")
                        .HasColumnType("integer")
                        .HasColumnName("ResponsibleUser");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("StartDate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ResponsibleUserId");

                    b.ToTable("ExtensionProject", (string)null);
                });

            modelBuilder.Entity("Models.Business.ExtensionProjectStatusLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CreatedBy");

                    b.Property<int>("ExtensionProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("ExtensionProjectId");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("ExtensionProjectId");

                    b.ToTable("ExtensionProjectStatusLog", (string)null);
                });

            modelBuilder.Entity("Models.Business.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<int>("ExtensionProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("ExtensionProjectId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExtensionProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("Models.Business.Student_ExtensionProject", b =>
                {
                    b.Property<int>("ExtensionProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Stats")
                        .HasColumnType("integer");

                    b.Property<int>("Workload")
                        .HasColumnType("integer");

                    b.HasKey("ExtensionProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Student_ExtensionProject", (string)null);
                });

            modelBuilder.Entity("Models.Business.Teacher_ExtensionProject", b =>
                {
                    b.Property<int>("ExtensionProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ExtensionProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Teacher_ExtensionProject", (string)null);
                });

            modelBuilder.Entity("Models.Business.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("Registration");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Models.Business.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Models.Business.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Models.Business.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Models.Business.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Models.Business.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Business.Course_ExtensionProject", b =>
                {
                    b.HasOne("Models.Business.Course", "Course")
                        .WithMany("Course_ExtensionProjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.ExtensionProject", "ExtensionProject")
                        .WithMany("Course_ExtensionProjects")
                        .HasForeignKey("ExtensionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("ExtensionProject");
                });

            modelBuilder.Entity("Models.Business.Course_User", b =>
                {
                    b.HasOne("Models.Business.Course", "Course")
                        .WithMany("Course_Users")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.User", "User")
                        .WithMany("Course_Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Business.ExtensionProject", b =>
                {
                    b.HasOne("Models.Business.User", "ResponsibleUser")
                        .WithMany("ExtensionProjectResponsible")
                        .HasForeignKey("ResponsibleUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponsibleUser");
                });

            modelBuilder.Entity("Models.Business.ExtensionProjectStatusLog", b =>
                {
                    b.HasOne("Models.Business.ExtensionProject", "ExtensionProject")
                        .WithMany("ExtensionProjectStatusLogs")
                        .HasForeignKey("ExtensionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtensionProject");
                });

            modelBuilder.Entity("Models.Business.Report", b =>
                {
                    b.HasOne("Models.Business.ExtensionProject", "ExtensionProject")
                        .WithMany("Reports")
                        .HasForeignKey("ExtensionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtensionProject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Business.Student_ExtensionProject", b =>
                {
                    b.HasOne("Models.Business.ExtensionProject", "ExtensionProject")
                        .WithMany("Student_ExtensionProjects")
                        .HasForeignKey("ExtensionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.User", "User")
                        .WithMany("Student_ExtensionProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtensionProject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Business.Teacher_ExtensionProject", b =>
                {
                    b.HasOne("Models.Business.ExtensionProject", "ExtensionProject")
                        .WithMany("Teacher_ExtensionProjects")
                        .HasForeignKey("ExtensionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Business.User", "User")
                        .WithMany("Teacher_ExtensionProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtensionProject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Business.Course", b =>
                {
                    b.Navigation("Course_ExtensionProjects");

                    b.Navigation("Course_Users");
                });

            modelBuilder.Entity("Models.Business.ExtensionProject", b =>
                {
                    b.Navigation("Course_ExtensionProjects");

                    b.Navigation("ExtensionProjectStatusLogs");

                    b.Navigation("Reports");

                    b.Navigation("Student_ExtensionProjects");

                    b.Navigation("Teacher_ExtensionProjects");
                });

            modelBuilder.Entity("Models.Business.User", b =>
                {
                    b.Navigation("Course_Users");

                    b.Navigation("ExtensionProjectResponsible");

                    b.Navigation("Reports");

                    b.Navigation("Student_ExtensionProjects");

                    b.Navigation("Teacher_ExtensionProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
