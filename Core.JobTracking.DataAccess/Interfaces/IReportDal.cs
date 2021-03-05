using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetWithWorkId(int id);

        int GetTotalReportNumberWithAppUserId(int id);
        int GetTotalReportNumber();
    }
}
