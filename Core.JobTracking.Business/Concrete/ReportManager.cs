using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;

        }
        public void Delete(int id)
        {
            _reportDal.Delete(id);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public int GetTotalReportNumber()
        {
            return _reportDal.GetTotalReportNumber();
        }

        public int GetTotalReportNumberWithAppUserId(int id)
        {
            return _reportDal.GetTotalReportNumberWithAppUserId(id);
        }

        public Report GetWithId(int id)
        {
            return _reportDal.GetWithId(id);
        }

        public Report GetWithWorkId(int id)
        {
            return _reportDal.GetWithWorkId(id);
        }

        public void Save(Report work)
        {
            _reportDal.Save(work);
        }

        public void Update(Report param)
        {
            _reportDal.Update(param);
        }
    }
}
