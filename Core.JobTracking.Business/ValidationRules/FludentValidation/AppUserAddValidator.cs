using Core.JobTracking.DTO.DTOs.AppUserDtos;
using Core.JobTracking.DTO.DTOs.PriorityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.ValidationRules.FludentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(p => p.Password). NotNull().WithMessage("Şifre Alanı  Boş Geçilemez");
            RuleFor(p => p.ConfirmPassword).NotNull().WithMessage("Şifre Onay Alanı Boş Geçilemez");
            RuleFor(p => p.Password).Equal(p => p.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(p => p.Email).NotNull().WithMessage("Email Alanı Boş Geçilemez").EmailAddress().WithMessage("Geçersiz Emaail Adresi");
            RuleFor(p => p.Name).NotNull().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(p => p.Surname).NotNull().WithMessage("Soyadı Alanı Boş Geçilemez");

        }
    }
}


