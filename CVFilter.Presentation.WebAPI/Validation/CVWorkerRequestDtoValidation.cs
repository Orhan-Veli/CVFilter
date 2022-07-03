using CVFilter.Application.Dto;
using FluentValidation;

namespace CVFilter.Presentation.WebAPI.Validation
{
    public class CVWorkerRequestDtoValidation : AbstractValidator<CVWorkerRequestDto>
    {
        public CVWorkerRequestDtoValidation()
        {
            RuleFor(x => x.LanguageMatches).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.EducationMatches).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.RequiredMatches).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Experience).Must(x => x > 0);
            RuleFor(x => x.Path).NotNull().NotEmpty().MinimumLength(250);
        }
    }
}
