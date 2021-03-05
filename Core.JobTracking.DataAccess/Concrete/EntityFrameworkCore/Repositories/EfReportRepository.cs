using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public int GetTotalReportNumber()
        {
            using var context = new JobTrackingContext();
            return context.Reports.Count();
        }

        public int GetTotalReportNumberWithAppUserId(int id)
        {
            using var context = new JobTrackingContext();
            var result = context.Works.Include(p => p.Reports).Where(p => p.AppUserId == id);
            return result.SelectMany(p => p.Reports).Count();


            //user -> work -> report
        }

        public Report GetWithWorkId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Reports.Include(p => p.Work).ThenInclude(p=>p.Priority).FirstOrDefault(p=>p.Id==id);
        }
    }
}
