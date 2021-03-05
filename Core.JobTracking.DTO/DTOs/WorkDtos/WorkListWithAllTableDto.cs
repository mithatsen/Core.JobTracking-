using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.WorkDtos
{
    public class WorkListWithAllTableDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime CreationDate { get; set; }
        public Priority Priority { get; set; }
        public List<Report> Reports { get; set; }
        public AppUser AppUser { get; set; }
    }
}
