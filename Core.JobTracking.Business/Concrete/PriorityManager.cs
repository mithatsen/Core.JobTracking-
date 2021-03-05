using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class PriorityManager : IPriorityService
    {
        private readonly IPriorityDal _priorityDal;
        public PriorityManager(IPriorityDal priorityDal)
        {
            _priorityDal = priorityDal;
        }
        public void Delete(int id)
        {
            _priorityDal.Delete(id);
        }

        public List<Priority> GetAll()
        {
            return _priorityDal.GetAll();
        }

        public Priority GetWithId(int id)
        {
            return _priorityDal.GetWithId(id);
        }

        public void Save(Priority param)
        {
            _priorityDal.Save(param);
        }

        public void Update(Priority param)
        {
            _priorityDal.Update(param);
        }
    }
}
