using Core.JobTracking.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.AppUserDtos
{
    public class PersonelAssignListDto
    {
        public AppUserListDto User { get; set; }
        public WorkListDto Work { get; set; }
    }
}
