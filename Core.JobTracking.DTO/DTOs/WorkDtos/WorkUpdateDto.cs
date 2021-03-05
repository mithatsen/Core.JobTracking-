using Core.JobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.WorkDtos
{
    public class WorkUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Görev Adı")]
        //[Required(ErrorMessage = "Görev adı boş geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Görev Açıklaması")]
        //[Required(ErrorMessage = "Görev açıklaması boş geçilemez")]
        public string Explanation { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen aciliyet durumu seçiniz")]
        public int PriorityId { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
