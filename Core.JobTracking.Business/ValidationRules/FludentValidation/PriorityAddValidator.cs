using Core.JobTracking.DTO.DTOs.PriorityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.ValidationRules.FludentValidation
{
    public class PriorityAddValidator : AbstractValidator<PriorityAddDto>
    {
        public PriorityAddValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Tanım alanı boş geçilemez.");
        }

    }
}
