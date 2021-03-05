using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto
    {
        //[Required(ErrorMessage = "Email Boş Geçilemez")]
        //[Display(Name = "E-mail")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Şifre  Boş Geçilemez")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Şifre")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
