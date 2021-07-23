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
    public class MaterialMappingConfig : IEntityTypeConfiguration<MaterialEntity>
    {
        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            builder.ToTable("Materials", "sch");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsUnicode();

            builder.HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedMaterials)
                .HasForeignKey(x => x.CreatedUserId)
                .HasConstraintName("FK_CreatedByUser_CreatedMaterials_CreatedUserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Users)
                .WithMany(x => x.FinishedMaterials)
                .UsingEntity(j => j.ToTable("Users_FinishedMaterials_Enrollments"));

        }
    }
}
