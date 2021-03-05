using Core.JobTracking.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface IGenericService<T> where T : class, ITable, new()
    {
        void Save(T param);
        void Delete(int id);
        void Update(T param);
        T GetWithId(int id);
        List<T> GetAll();
    }
}
