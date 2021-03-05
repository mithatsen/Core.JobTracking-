using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetNotRead(int AppUserId);
        int GetNotReadNumber(int AppUserId);
    }
}
