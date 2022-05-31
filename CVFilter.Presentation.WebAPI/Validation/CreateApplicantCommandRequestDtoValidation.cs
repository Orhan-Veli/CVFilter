using CVFilter.Application.Dto;
using FluentValidation;

namespace CVFilter.Presentation.WebAPI.Validation
{
    public class CreateApplicantCommandRequestDtoValidation : AbstractValidator<CreateApplicantCommandRequestDto>
    {
        public CreateApplicantCommandRequestDtoValidation()
        {
            RuleFor(x => x.Matches).NotNull().NotEmpty().MaximumLength(50).Must(c=>c.Contains(','));
            RuleFor(x => x.Path).NotNull().NotEmpty().MinimumLength(250);
            RuleFor(x => x.User).NotNull().NotEmpty();
        }
    }
}
