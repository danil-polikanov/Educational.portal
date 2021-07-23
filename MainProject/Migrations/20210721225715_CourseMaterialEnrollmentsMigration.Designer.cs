﻿// <auto-generated />
using System;
using MainProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MainProject.Migrations
{
    [DbContext(typeof(EducationPortalDbContext))]
    [Migration("20210721225715_CourseMaterialEnrollmentsMigration")]
    partial class CourseMaterialEnrollmentsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sch")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MainProject.Core.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedByUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id")
                        .HasName("PK_Courses")
                        .IsClustered();

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Courses", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByUserId = 1,
                            Description = "Изучение C#",
                            Name = "Курс С#"
                        },
                        new
                        {
                            Id = 2,
                            CreatedByUserId = 1,
                            Description = "Изучение Html",
                            Name = "Курс Html"
                        },
                        new
                        {
                            Id = 3,
                            CreatedByUserId = 1,
                            Description = "Изучение Css",
                            Name = "Курс Css"
                        });
                });

            modelBuilder.Entity("MainProject.Core.CourseMaterialEnrollment", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("MaterialId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseMaterialEnrollments");
                });

            modelBuilder.Entity("MainProject.Core.CourseSkillEnrollment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("CourseId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillCourseEntrollments");

                    b.HasData(
                        new
                        {
                            CourseId = 2,
                            SkillId = 2,
                            RequirementLevel = 1
                        });
                });

            modelBuilder.Entity("MainProject.Core.MaterialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id")
                        .IsClustered();

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Materials", "sch");
                });

            modelBuilder.Entity("MainProject.Core.PassingCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsComplete")
                        .HasMaxLength(12)
                        .HasColumnType("bit");

                    b.Property<double>("Progress")
                        .HasMaxLength(12)
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PassingCourses")
                        .IsClustered();

                    b.HasIndex("CourseId");

                    b.ToTable("PassingCourse", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            IsComplete = false,
                            Progress = 0.0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            IsComplete = false,
                            Progress = 0.0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            IsComplete = false,
                            Progress = 0.0,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("MainProject.Core.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AdminRole"
                        },
                        new
                        {
                            Id = 2,
                            Name = "UserRole"
                        });
                });

            modelBuilder.Entity("MainProject.Core.SkillEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id")
                        .HasName("PK_Skills")
                        .IsClustered();

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Skills", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedUserId = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            CreatedUserId = 1,
                            Name = "Html"
                        },
                        new
                        {
                            Id = 3,
                            CreatedUserId = 1,
                            Name = "Css"
                        },
                        new
                        {
                            Id = 4,
                            CreatedUserId = 2,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("MainProject.Core.SkillUserEnrollment", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("SkillId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("SkillUserEnrollments");

                    b.HasData(
                        new
                        {
                            SkillId = 4,
                            UserId = 4,
                            Level = 3
                        });
                });

            modelBuilder.Entity("MainProject.Core.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Login")
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Users")
                        .IsClustered();

                    b.HasIndex("RoleId");

                    b.ToTable("Users", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "renekton73@gmail.com",
                            Login = "Admin",
                            Password = "11221122d",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Syino@gmail.com",
                            Login = "Syino",
                            Password = "qwerty123",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "Danya@gmail.com",
                            Login = "Danya",
                            Password = "11221122",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "Ment@gmail.com",
                            Login = "Ment",
                            Password = "321",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("MaterialEntityUserEntity", b =>
                {
                    b.Property<int>("FinishedMaterialsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("FinishedMaterialsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Users_FinishedMaterials_Enrollments");
                });

            modelBuilder.Entity("PassingCourseUserEntity", b =>
                {
                    b.Property<int>("PassingCoursesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PassingCoursesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Users_PassingCourses_Enrollments");
                });

            modelBuilder.Entity("MainProject.Core.ElectronicPublicationEntity", b =>
                {
                    b.HasBaseType("MainProject.Core.MaterialEntity");

                    b.Property<string>("Authors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("YearOfPublishing")
                        .HasColumnType("int");

                    b.ToTable("ElectronicPublication");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedUserId = 1,
                            Name = "Патерное программирование C#",
                            Authors = "Daniel,Marine",
                            Format = ".docx",
                            NumberOfPages = 30,
                            YearOfPublishing = 2011
                        },
                        new
                        {
                            Id = 2,
                            CreatedUserId = 1,
                            Name = "Основы Html",
                            Authors = "Urfic,Dasha",
                            Format = ".pdf",
                            NumberOfPages = 60,
                            YearOfPublishing = 2018
                        });
                });

            modelBuilder.Entity("MainProject.Core.InternetArticleEntity", b =>
                {
                    b.HasBaseType("MainProject.Core.MaterialEntity");

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Wiki")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InternetArticle");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CreatedUserId = 1,
                            Name = "Метанит",
                            DateOfPublication = new DateTime(2015, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Wiki = "www.metanit.com"
                        },
                        new
                        {
                            Id = 4,
                            CreatedUserId = 1,
                            Name = "HtmlBox",
                            DateOfPublication = new DateTime(2018, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Wiki = "www.htmlbox.com"
                        });
                });

            modelBuilder.Entity("MainProject.Core.VideoResourceEntity", b =>
                {
                    b.HasBaseType("MainProject.Core.MaterialEntity");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Quality")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VideoResource");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CreatedUserId = 1,
                            Name = "Основы языка С#",
                            Duration = new TimeSpan(0, 3, 25, 30, 0),
                            Quality = "720р"
                        },
                        new
                        {
                            Id = 6,
                            CreatedUserId = 1,
                            Name = "Основы верстки Html",
                            Duration = new TimeSpan(0, 1, 15, 15, 0),
                            Quality = "1080р"
                        });
                });

            modelBuilder.Entity("MainProject.Core.CourseEntity", b =>
                {
                    b.HasOne("MainProject.Core.UserEntity", "CreatedByUser")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("FK_CreatedCourses_CreatedByUser_CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("MainProject.Core.CourseMaterialEnrollment", b =>
                {
                    b.HasOne("MainProject.Core.CourseEntity", "Course")
                        .WithMany("CourseMaterialEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProject.Core.MaterialEntity", "Material")
                        .WithMany("CourseMaterialEnrollments")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MainProject.Core.CourseSkillEnrollment", b =>
                {
                    b.HasOne("MainProject.Core.CourseEntity", "Course")
                        .WithMany("CourseSkillEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProject.Core.SkillEntity", "Skill")
                        .WithMany("CourseSkillEnrollments")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("MainProject.Core.MaterialEntity", b =>
                {
                    b.HasOne("MainProject.Core.UserEntity", "CreatedByUser")
                        .WithMany("CreatedMaterials")
                        .HasForeignKey("CreatedUserId")
                        .HasConstraintName("FK_CreatedByUser_CreatedMaterials_CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("MainProject.Core.PassingCourse", b =>
                {
                    b.HasOne("MainProject.Core.CourseEntity", "Course")
                        .WithMany("PassingCourses")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_Course_PassingCourses_CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MainProject.Core.SkillEntity", b =>
                {
                    b.HasOne("MainProject.Core.UserEntity", "CreatedByUser")
                        .WithMany("CreatedSKills")
                        .HasForeignKey("CreatedUserId")
                        .HasConstraintName("FK_CreatedSKills_CreatedByUser_CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("MainProject.Core.SkillUserEnrollment", b =>
                {
                    b.HasOne("MainProject.Core.SkillEntity", "Skill")
                        .WithMany("SkillUserEnrollments")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProject.Core.UserEntity", "User")
                        .WithMany("SkillUserEnrollments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MainProject.Core.UserEntity", b =>
                {
                    b.HasOne("MainProject.Core.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MaterialEntityUserEntity", b =>
                {
                    b.HasOne("MainProject.Core.MaterialEntity", null)
                        .WithMany()
                        .HasForeignKey("FinishedMaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProject.Core.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassingCourseUserEntity", b =>
                {
                    b.HasOne("MainProject.Core.PassingCourse", null)
                        .WithMany()
                        .HasForeignKey("PassingCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProject.Core.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainProject.Core.ElectronicPublicationEntity", b =>
                {
                    b.HasOne("MainProject.Core.MaterialEntity", null)
                        .WithOne()
                        .HasForeignKey("MainProject.Core.ElectronicPublicationEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainProject.Core.InternetArticleEntity", b =>
                {
                    b.HasOne("MainProject.Core.MaterialEntity", null)
                        .WithOne()
                        .HasForeignKey("MainProject.Core.InternetArticleEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainProject.Core.VideoResourceEntity", b =>
                {
                    b.HasOne("MainProject.Core.MaterialEntity", null)
                        .WithOne()
                        .HasForeignKey("MainProject.Core.VideoResourceEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainProject.Core.CourseEntity", b =>
                {
                    b.Navigation("CourseMaterialEnrollments");

                    b.Navigation("CourseSkillEnrollments");

                    b.Navigation("PassingCourses");
                });

            modelBuilder.Entity("MainProject.Core.MaterialEntity", b =>
                {
                    b.Navigation("CourseMaterialEnrollments");
                });

            modelBuilder.Entity("MainProject.Core.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MainProject.Core.SkillEntity", b =>
                {
                    b.Navigation("CourseSkillEnrollments");

                    b.Navigation("SkillUserEnrollments");
                });

            modelBuilder.Entity("MainProject.Core.UserEntity", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("CreatedMaterials");

                    b.Navigation("CreatedSKills");

                    b.Navigation("SkillUserEnrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
