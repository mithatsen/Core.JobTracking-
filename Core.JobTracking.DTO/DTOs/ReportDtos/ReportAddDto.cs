using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.ReportDtos
{
    public class ReportAddDto
    {
        //[Display(Name = "Başlık")]
        //[Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Name { get; set; }

        //[Display(Name = "İçerik")]
        //[Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Detail { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}
