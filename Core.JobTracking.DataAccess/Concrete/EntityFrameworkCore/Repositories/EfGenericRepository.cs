using Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Interfaces;

using System.Collections.Generic;
using System.Linq;


namespace Core.JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        public void Delete(int id)
        {
            using var context = new JobTrackingContext();
            var temp = context.Set<T>().Find(id);
            context.Set<T>().Remove(temp);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new JobTrackingContext();
            return context.Set<T>().ToList();
        }

        public T GetWithId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Set<T>().Find(id);
        }

        public void Save(T param)
        {
            using var context = new JobTrackingContext();
            context.Set<T>().Add(param);
            context.SaveChanges();

        }

        public void Update(T param)
        {
            using var context = new JobTrackingContext();
            context.Set<T>().Update(param);
            context.SaveChanges();

        }
    }
}

//context.calisma=context.Set<Calisma>()