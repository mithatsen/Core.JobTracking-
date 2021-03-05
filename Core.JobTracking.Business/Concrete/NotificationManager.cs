using Core.JobTracking.Business.Interfaces;
using Core.JobTracking.DataAccess.Interfaces;
using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Delete(int id)
        {
            _notificationDal.Delete(id);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetNotRead(int AppUserId)
        {
            return _notificationDal.GetNotRead(AppUserId);
        }

        public int GetNotReadNumber(int AppUserId)
        {
            return _notificationDal.GetNotReadNumber(AppUserId);
        }

        public Notification GetWithId(int id)
        {
            return _notificationDal.GetWithId(id);
        }

        public void Save(Notification param)
        {
            _notificationDal.Save(param);
        }

        public void Update(Notification param)
        {
            _notificationDal.Update(param);
        }
    }
}
