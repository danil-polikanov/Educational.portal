using MainProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MainProject.Data
{
    public class EducationPortalDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<PassingCourse> PassingCourses { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<VideoResourceEntity> VideoMaterials { get; set; }
        public DbSet<InternetArticleEntity> InternetMaterials { get; set; }
        public DbSet<ElectronicPublicationEntity> ElectronicMaterials { get; set; }
        public DbSet<CourseSkillEnrollment> CourseSkillEnrollments { get; set; }
        public DbSet<SkillUserEnrollment> SkillUserEnrollments { get; set; }

        public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ElectronicPublicationEntity>().ToTable("ElectronicPublication");
            modelBuilder.Entity<InternetArticleEntity>().ToTable("InternetArticle");
            modelBuilder.Entity<VideoResourceEntity>().ToTable("VideoResource");

   
            modelBuilder.Entity<SkillUserEnrollment>().HasData(
                    new SkillUserEnrollment[]
                    {
                       new SkillUserEnrollment{UserId=4,SkillId=4,Level=3}
                    });

            modelBuilder.Entity<CourseSkillEnrollment>().HasData(
                    new CourseSkillEnrollment[]
                    {
                       new CourseSkillEnrollment{CourseId=2,SkillId=2,RequirementLevel=1}
                    });


            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity[]
                {
                    new UserEntity { Id=1,Login="Admin",Email = "renekton73@gmail.com",Password="11221122d",RoleId=1},
                    new UserEntity { Id=2,Login="Syino",Email = "Syino@gmail.com", Password = "qwerty123",RoleId=2},
                    new UserEntity { Id=3, Login="Danya",Email = "Danya@gmail.com", Password = "11221122",RoleId=2},
                    new UserEntity { Id=4, Login="Ment",Email = "Ment@gmail.com", Password = "321",RoleId=2 }
                });

            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id=1,Name="AdminRole"},
                    new Role { Id=2,Name="UserRole"}
                });


            modelBuilder.Entity<SkillEntity>().HasData(
                new SkillEntity[]
                {
                    new SkillEntity { Id=1,Name="C#",CreatedUserId=1,},
                    new SkillEntity { Id=2,Name="Html",CreatedUserId=1},
                    new SkillEntity { Id=3,Name="Css",CreatedUserId=1},
                    new SkillEntity { Id=4,Name="Test",CreatedUserId=2}
                });

            modelBuilder.Entity<ElectronicPublicationEntity>().HasData(
                new ElectronicPublicationEntity[]
                {
                    new ElectronicPublicationEntity { Id = 1,Name="Патерное программирование C#",Authors="Daniel,Marine", NumberOfPages=30,Format=".docx",YearOfPublishing=2011,CreatedUserId=1},
                    new ElectronicPublicationEntity { Id = 2, Name="Основы Html",Authors= "Urfic,Dasha", NumberOfPages=60,Format=".pdf",YearOfPublishing=2018,CreatedUserId=1}
                });
            modelBuilder.Entity<InternetArticleEntity>().HasData(
                new InternetArticleEntity[]
                {
                    new InternetArticleEntity { Id = 3,Name="Метанит",DateOfPublication=new DateTime(2015,5,30),Wiki="www.metanit.com",CreatedUserId=1 },
                    new InternetArticleEntity { Id = 4,Name="HtmlBox",DateOfPublication=new DateTime(2018,3,15),Wiki="www.htmlbox.com",CreatedUserId=1 },

                });
            modelBuilder.Entity<VideoResourceEntity>().HasData(
                new VideoResourceEntity[]
                {
                    new VideoResourceEntity { Id = 5, Name="Основы языка С#",Quality="720р",Duration=new TimeSpan(3,25,30),CreatedUserId=1},
                    new VideoResourceEntity { Id = 6, Name="Основы верстки Html",Quality="1080р",Duration=new TimeSpan(1,15,15),CreatedUserId=1},

                });

            modelBuilder.Entity<CourseEntity>().HasData(
                  new CourseEntity[]
                  {new CourseEntity {Id=1,Name="Курс С#",Description="Изучение C#",CreatedByUserId=1},
                   new CourseEntity {Id=2,Name="Курс Html",Description="Изучение Html",CreatedByUserId=1},
                   new CourseEntity {Id=3,Name="Курс Css",Description="Изучение Css",CreatedByUserId=1},
                });


            modelBuilder.Entity<PassingCourse>().HasData(
                new PassingCourse[]
                {
                    new PassingCourse {Id=1,CourseId=1,UserId=2,IsComplete=false,Progress=0},
                    new PassingCourse {Id=2,CourseId=2,UserId=3,IsComplete=false,Progress=0 },
                    new PassingCourse {Id=3,CourseId=3,UserId=3,IsComplete=false,Progress=0 }
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}
