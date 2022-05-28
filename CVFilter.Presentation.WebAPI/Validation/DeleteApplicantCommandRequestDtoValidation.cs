using CVFilter.Application.Dto;
using FluentValidation;
using System;

namespace CVFilter.Presentation.WebAPI.Validation
{
    public class DeleteApplicantCommandRequestDtoValidation : AbstractValidator<DeleteApplicantCommandRequestDto>
    {
        public DeleteApplicantCommandRequestDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
