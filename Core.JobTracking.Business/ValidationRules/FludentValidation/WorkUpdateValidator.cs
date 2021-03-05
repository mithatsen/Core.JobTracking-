using Core.JobTracking.DTO.DTOs.WorkDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.ValidationRules.FludentValidation
{
    public class WorkUpdateValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(p => p.PriorityId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
