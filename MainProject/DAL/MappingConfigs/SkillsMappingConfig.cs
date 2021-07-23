using MainProject.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.MappingConfigs
{

    public class SkillsMappingConfig : IEntityTypeConfiguration<SkillEntity>
    {
        public void Configure(EntityTypeBuilder<SkillEntity> builder)
        {
            builder.ToTable("Skills", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Skills")
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsUnicode();

 
            builder.HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedSKills)
                .HasForeignKey(x => x.CreatedUserId)
                .HasConstraintName("FK_CreatedByUser_CreatedSKills_CreatedUserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(c => c.Users)
                   .WithMany(s => s.Skills)
                   .UsingEntity<SkillUserEnrollment>(
                      j => j
                       .HasOne(pt => pt.User)
                       .WithMany(t => t.SkillUserEnrollments)
                       .HasForeignKey(pt => pt.UserId),
                   j => j
                       .HasOne(pt => pt.Skill)
                       .WithMany(p => p.SkillUserEnrollments)
                       .HasForeignKey(pt => pt.SkillId),
                   j =>
                   {
                       j.Property(pt => pt.Level).HasDefaultValue(0);
                       j.HasKey(t => new { t.SkillId, t.UserId });
                       j.ToTable("SkillUserEnrollments");
                   });
            builder
                .HasMany(c => c.Courses)
                .WithMany(s => s.Skills)
                .UsingEntity<CourseSkillEnrollment>(
                  j => j
                .HasOne(pt => pt.Course)
                .WithMany(t => t.CourseSkillEnrollments)
                .HasForeignKey(pt => pt.CourseId),
                     j => j
                .HasOne(pt => pt.Skill)
                .WithMany(p => p.CourseSkillEnrollments)
                .HasForeignKey(pt => pt.SkillId),
                j =>
                {
                    j.Property(pt => pt.RequirementLevel).HasDefaultValue(0);
                    j.HasKey(t => new { t.CourseId, t.SkillId });
                    j.ToTable("SkillCourseEntrollments");
                });

        }
    }

}
