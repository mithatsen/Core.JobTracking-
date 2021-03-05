using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface IWorkingService : IGenericService<Work>
    {
        List<Work> GetNotCompletedWorkWithAscDate();
        List<Work> GetWorksWithAllTable();
        List<Work> GetWorksWithAllTable(Expression<Func<Work, bool>> filter);
        List<Work> GetWorksWithAppUserId(int appUserId);
        Work GetWithPriorityId(int id);
        Work GetWithReportId(int id);
        List<Work> GetFinishedWorksWithAllTable(out int totalPages, int userId, int activePage=1);
        int GetFinisheWorkNumberWithAppUserId(int id);
        int GetNotFinishedWorkNumberWithAppUserId(int id);
        int GetNotAssignedWorkNumber();
        int GetFinishedWorkNumber();
        Work GetWithAppUserId(int id);

    }
}
