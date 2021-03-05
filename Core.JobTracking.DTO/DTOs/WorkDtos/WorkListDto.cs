using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.WorkDtos
{
    public class WorkListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Explanation { get; set; }

        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public int? PriorityId { get; set; } // nullable yaptık çünkü ilk work oluşturulursa burayı boş geçemeyiz

        public Priority Priority { get; set; }
    }
}
