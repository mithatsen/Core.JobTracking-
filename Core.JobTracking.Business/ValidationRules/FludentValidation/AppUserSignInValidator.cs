using Core.JobTracking.DTO.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.ValidationRules.FludentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre Alanı  Boş Geçilemez");
        }

       
    }
}
