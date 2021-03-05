using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPriorityRepository :EfGenericRepository<Priority>,IPriorityDal
    {
    }
}
