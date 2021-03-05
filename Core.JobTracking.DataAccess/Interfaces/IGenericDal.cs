using Core.JobTracking.Entities.Interfaces;

using System.Collections.Generic;


namespace Core.JobTracking.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T:class,ITable,new()
    {
        void Save(T work);
        void Delete(int id);
        void Update(T param);
        T GetWithId(int id);
        List<T> GetAll();
        

    }
}
