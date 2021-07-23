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
    public class UserMappingConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users", "sch");

            builder.HasKey(x => x.Id)
                .HasName("PK_Users")
                .IsClustered();

            builder.Property(x => x.Login)
                .HasMaxLength(30)
                .IsUnicode();


            builder.Property(x => x.Email)
                .HasMaxLength(32)
                .IsUnicode();

            builder.Property(x => x.Password)
                .HasMaxLength(32)
                .IsUnicode();


            builder.HasMany(x => x.CreatedCourses)
                .WithOne(x => x.CreatedByUser)
                .HasForeignKey(x => x.CreatedByUserId)
                .HasConstraintName("FK_CreatedCourses_CreatedByUser_CreatedByUserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CreatedMaterials)
                 .WithOne(x => x.CreatedByUser)
                 .HasForeignKey(x => x.CreatedUserId)
                 .HasConstraintName("FK_CreatedByUser_CreatedMaterials_CreatedUserId")
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CreatedSKills)
                .WithOne(x => x.CreatedByUser)
                .HasForeignKey(x => x.CreatedUserId)
                .HasConstraintName("FK_CreatedSKills_CreatedByUser_CreatedUserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.FinishedMaterials)
                .WithMany(x => x.Users)
                .UsingEntity(j => j.ToTable("Users_FinishedMaterials_Enrollments"));

            builder.HasMany(x => x.PassingCourses)
                .WithMany(x => x.Users)
                .UsingEntity(j => j.ToTable("Users_PassingCourses_Enrollments"));
        }
    }
}
