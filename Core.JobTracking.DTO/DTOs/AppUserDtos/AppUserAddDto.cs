using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.DTO.DTOs.AppUserDtos
{
    public class AppUserAddDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        //[Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Şifre")]

        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        //[Display(Name = "Şifre Onayı")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Email Alanı Boş Geçilemez")]
        //[EmailAddress(ErrorMessage = "Geçersiz Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Ad Alanı  Boş Geçilemez")]
        //[Display(Name = "Ad")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Soyad Alanı Boş Geçilemez")]
        //[Display(Name = "Soyad")]
        public string Surname { get; set; }
    }
}
