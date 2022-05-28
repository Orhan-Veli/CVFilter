using CVFilter.Application.Dto;
using FluentValidation;

namespace CVFilter.Presentation.WebAPI.Validation
{
    public class GetApplicantQueryRequestDtoValidation : AbstractValidator<GetApplicantQueryRequestDto>
    {
        public GetApplicantQueryRequestDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
