using Core.JobTracking.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Entities.Concrete
{
    public class Notification :ITable
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Explanation { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}
