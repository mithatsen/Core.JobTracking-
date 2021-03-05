using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetNotRead(int AppUserId)
        {
            using var context = new JobTrackingContext();
            return context.Notifications.Where(p => !p.Status && p.AppUserId == AppUserId).ToList();

        }

        public int GetNotReadNumber(int AppUserId)
        {
            using var context = new JobTrackingContext();
            return context.Notifications.Count(p => !p.Status && p.AppUserId == AppUserId);
        }
    }
}
