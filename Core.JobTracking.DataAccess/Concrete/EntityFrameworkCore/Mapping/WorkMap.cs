using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(200).IsRequired();
            builder.Property(I => I.Explanation).HasColumnType("ntext");


            builder.HasOne
                (p => p.Priority).WithMany
                (p => p.Works).HasForeignKey
                (p => p.PriorityId);

            builder.HasMany
                (p => p.Reports).WithOne
                (p => p.Work).HasForeignKey
                (p => p.WorkId);

        }
    }
}
