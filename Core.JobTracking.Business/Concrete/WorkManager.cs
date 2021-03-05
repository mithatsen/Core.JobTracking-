using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class WorkManager: IWorkingService
    {
        private readonly IWorkingDal _workingDal;
        public WorkManager(IWorkingDal workingDal)
        {
            _workingDal = workingDal;

        }
        public void Delete(int id)
        {
            _workingDal.Delete(id);
        }

        public List<Work> GetAll()
        {
            return _workingDal.GetAll();
        }

        public int GetFinishedWorkNumber()
        {
            return _workingDal.GetFinishedWorkNumber();
        }

        public List<Work> GetFinishedWorksWithAllTable(out int totalPages, int userId, int activePage=1)
        {          
            return _workingDal.GetFinishedWorksWithAllTable(out totalPages,userId,activePage);
        }

        public int GetFinisheWorkNumberWithAppUserId(int id)
        {
            return _workingDal.GetFinisheWorkNumberWithAppUserId(id);
        }

        public int GetNotAssignedWorkNumber()
        {
            return _workingDal.GetNotAssignedWorkNumber();
        }

        public List<Work> GetNotCompletedWorkWithAscDate()
        {
            return _workingDal.GetNotCompletedWorkWithAscDate();
        }

        public int GetNotFinishedWorkNumberWithAppUserId(int id)
        {
            return _workingDal.GetNotFinishedWorkNumberWithAppUserId(id);
        }

        public Work GetWithAppUserId(int id)
        {
            return _workingDal.GetWithAppUserId(id);
        }

        public Work GetWithId(int id)
        {
            return _workingDal.GetWithId(id);
        }

        public Work GetWithPriorityId(int id)
        {
            return _workingDal.GetWithPriorityId(id);
        }

        public Work GetWithReportId(int id)
        {
            return _workingDal.GetWithReportId(id);
        }

        public List<Work> GetWorksWithAllTable()
        {
            return _workingDal.GetWorksWithAllTable();
        }

        public List<Work> GetWorksWithAllTable(Expression<Func<Work, bool>> filter)
        {
            return _workingDal.GetWorksWithAllTable(filter);
        }

        public List<Work> GetWorksWithAppUserId(int appUserId)
        {
            return _workingDal.GetWorksWithAppUserId(appUserId);
        }

        public void Save(Work param)
        {
            _workingDal.Save(param);
        }

        public void Update(Work param)
        {
            _workingDal.Update(param);
        }
    }
}
