using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name boş bırakılamaz");
            RuleFor(c => c.Name).MinimumLength(5).WithMessage("Name 5 karakterden kucuk olamaz");
        }
    }
}
