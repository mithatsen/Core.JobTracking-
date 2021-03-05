using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Core.JobTracking.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class JobTrackingContext : IdentityDbContext<AppUser,AppRole,int>  // eskiden db contexti artık identity db contexten kalıtım alır
    {
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3KEFFM2\\SQLEXPRESS; database=dbCoreJobTracking; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new WorkMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new PriorityMap());
            modelBuilder.ApplyConfiguration(new AppUserMapping());
            modelBuilder.ApplyConfiguration(new NotificationMapping());
            base.OnModelCreating(modelBuilder); // ıdentityden dolayı böyle bir durum söz konusu
        }
        
        public DbSet<Work> Works { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        

    }
}
