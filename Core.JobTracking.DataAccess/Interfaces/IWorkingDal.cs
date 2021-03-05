using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.JobTracking.DataAccess.Interfaces
{
    public interface IWorkingDal:IGenericDal<Work>
    {
        List<Work> GetNotCompletedWorkWithAscDate();

        List<Work> GetWorksWithAllTable();
        List<Work> GetWorksWithAllTable(Expression<Func<Work,bool>> filter );
        List<Work> GetWorksWithAppUserId(int appUserId);

        Work GetWithPriorityId(int id);
        Work GetWithReportId(int id);
        Work GetWithAppUserId(int id);

        List<Work> GetFinishedWorksWithAllTable(out int totalPages,int userId, int activePage);

        int GetFinisheWorkNumberWithAppUserId(int id);
        int GetNotFinishedWorkNumberWithAppUserId(int id);

        int GetNotAssignedWorkNumber();
        int GetFinishedWorkNumber();




    }
}
