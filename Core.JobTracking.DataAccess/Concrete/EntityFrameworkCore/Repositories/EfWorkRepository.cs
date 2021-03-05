
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{

    public class EfWorkRepository : EfGenericRepository<Work>, IWorkingDal
    {
        public int GetFinishedWorkNumber()
        {
            using var context = new JobTrackingContext();
            return context.Works.Count(p=>p.Status);
        }

        public int GetFinisheWorkNumberWithAppUserId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Works.Where(p => p.AppUserId == id && p.Status).Count();
        }

        public int GetNotAssignedWorkNumber()
        {
            using var context = new JobTrackingContext();
            return context.Works.Count(p => p.AppUserId == null && !p.Status);

        }

        public List<Work> GetNotCompletedWorkWithAscDate()
        {
            using var context = new JobTrackingContext();
            return context.Works.Include(p => p.Priority).Where(p => !p.Status).OrderByDescending(p => p.CreationDate).ToList();
        }

        public int GetNotFinishedWorkNumberWithAppUserId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Works.Where(p => p.AppUserId == id && !p.Status).Count();
        }

        public Work GetWithAppUserId(int id)
        {
            using (var context = new JobTrackingContext())
            {
                return context.Works.Include(p => p.AppUser).Include(p => p.Priority).FirstOrDefault(p=>p.Id == id);
            }
        }

        public Work GetWithPriorityId(int id)
        {
            using (var context = new JobTrackingContext())
            {
                return context.Works.Include(p => p.Priority).FirstOrDefault(p => !p.Status && p.Id == id);
            }
        }

        public Work GetWithReportId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Works.Include(p => p.Reports).Include(p => p.AppUser).FirstOrDefault(p => !p.Status && p.Id == id);
        }

        public List<Work> GetWorksWithAllTable()
        {
            using (var context = new JobTrackingContext())
            {
                return context.Works.Include(p => p.Priority).Include(p => p.AppUser).Include(p => p.Reports).Where(p => !p.Status).OrderByDescending(p => p.CreationDate).ToList();
            }
        }

        public List<Work> GetWorksWithAllTable(Expression<Func<Work, bool>> filter)
        {
            using (var context = new JobTrackingContext())
            {
                return context.Works.Include(p => p.Priority).Include(p => p.AppUser).Include(p => p.Reports).Where(filter).OrderByDescending(p => p.CreationDate).ToList();
            }
        }

        public List<Work> GetWorksWithAppUserId(int appUserId)
        {
            using var context = new JobTrackingContext();

            return context.Works.Where(p => p.AppUserId == appUserId).ToList();

        }

        List<Work> IWorkingDal.GetFinishedWorksWithAllTable(out int totalPages, int userId, int activePage = 1)
        {
            using var context = new JobTrackingContext();
            
            var returnValue = context.Works.Include(p => p.Priority).Include(p => p.AppUser).Include(p => p.Reports).Where(p => p.Status && p.AppUserId == userId).OrderByDescending(p => p.CreationDate);

            totalPages = (int)Math.Ceiling((double)returnValue.Count() / 3);
            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }
    }
}
