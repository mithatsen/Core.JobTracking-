using Core.JobTracking.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Entities.Concrete
{
    public class AppUser:IdentityUser<int> ,ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } 
        public List<Work> Works { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
