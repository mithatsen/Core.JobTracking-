using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.PriorityDtos
{
    public class PriorityUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Tanım")]
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }
    }
}
