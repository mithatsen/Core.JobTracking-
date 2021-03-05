using Core.JobTracking.DTO.DTOs.ReportDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.ValidationRules.FludentValidation
{
    public class ReportAddValidator: AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(p => p.Detail).NotNull().WithMessage("Detay alanı boş geçilemez.");
        }
    }
}
