using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface IReportService : IGenericService<Report> 
    {
        Report GetWithWorkId(int id);
        int GetTotalReportNumberWithAppUserId(int id);
        int GetTotalReportNumber();
    }
}
