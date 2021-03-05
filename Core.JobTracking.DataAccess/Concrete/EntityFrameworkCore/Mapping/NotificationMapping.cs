using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NotificationMapping :IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Explanation).HasColumnType("ntext").IsRequired();

            builder.HasOne
                (p => p.AppUser).WithMany
                (p => p.Notifications).HasForeignKey
                (p => p.AppUserId);

        }
    }
}
