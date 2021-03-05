using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Display(Name = "Ad")]
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        //[Display(Name = "Soyad")]
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        //[Required(ErrorMessage = "Email alanı boş geçilemez")]
        //[EmailAddress]
        public string Email { get; set; }
        //[Display(Name = "Resim")]
        public string Picture { get; set; }



       
    }
}

