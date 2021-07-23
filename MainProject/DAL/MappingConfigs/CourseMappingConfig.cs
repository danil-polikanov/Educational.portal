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
    public class CourseMappingConfig : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Courses")
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                  .IsUnicode();

            builder.Property(x => x.Description)
                .HasMaxLength(64)
                  .IsUnicode();

            builder.HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedCourses)
                .HasForeignKey(x => x.CreatedByUserId)
                .HasConstraintName("FK_CreatedByUser_CreatedCourses_CreatedByUserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasMany(c => c.Materials)
            .WithMany(s => s.Courses)
            .UsingEntity<CourseMaterialEnrollment>(
               j => j
                .HasOne(pt => pt.Material)
                .WithMany(t => t.CourseMaterialEnrollments)
                .HasForeignKey(pt => pt.MaterialId),
            j => j
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseMaterialEnrollments)
                .HasForeignKey(pt => pt.CourseId),
            j =>
            {
                j.HasKey(t => new { t.MaterialId, t.CourseId });
                j.ToTable("CourseMaterialEnrollments");
            });

        }
    }
}
