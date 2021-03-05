using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Surname).HasMaxLength(100);
            //app user içinde list tutan ,bire çok ilişkinin çok olan kısmı.Dolayısıyla

            builder.HasMany   //öNCE LİST TUTULANI AL
                (p => p.Works).WithOne // DAHA SONRA DİĞER TABLODAKİ TEK OLANI AL
                (p => p.AppUser).HasForeignKey // DAHA SONRA DİĞER ABLODAKİ FOREIGN KEYI BELIRT
                (p => p.AppUserId).OnDelete //SİLİNCE BÜTÜN GÖREVLERİ SİLMEMESİ İÇİN DEĞER ATA
                (DeleteBehavior.SetNull);

            
        }
    }
}
