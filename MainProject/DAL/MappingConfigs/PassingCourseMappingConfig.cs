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

    public class PassingCourseMappingConfig : IEntityTypeConfiguration<PassingCourse>
    {
        public void Configure(EntityTypeBuilder<PassingCourse> builder)
        {
            builder.ToTable("PassingCourse", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_PassingCourses")
                .IsClustered();

            builder.Property(x => x.IsComplete)
               .HasMaxLength(12);

            builder.Property(x => x.Progress)
                .HasMaxLength(12);

            builder.HasOne(x => x.Course)
               .WithMany(x => x.PassingCourses)
               .HasForeignKey(x => x.CourseId)
               .HasConstraintName("FK_Course_PassingCourses_CourseId")
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Users)
            .WithMany(x => x.PassingCourses)
            .UsingEntity(j => j.ToTable("Users_PassingCourses_Enrollments"));
        }
    }
}
