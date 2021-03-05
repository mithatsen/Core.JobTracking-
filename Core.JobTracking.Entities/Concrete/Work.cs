
using Core.JobTracking.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.JobTracking.Entities.Concrete
{
    public class Work:ITable
    {
        
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Explanation { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        public List<Report> Reports { get; set; }

        public int PriorityId { get; set; } 

        public Priority Priority { get; set; }

        public int? AppUserId { get; set; } // nullable yaptık çünkü ilk work oluşturulursa burayı boş geçemeyiz

        public AppUser AppUser { get; set; }


    }
}
