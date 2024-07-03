using FluentValidation;
using JWT.Api.DTOs;

namespace JWT.Api.Validations
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ad yeri bos ola bilmez");
            RuleFor(P => P.Surname).MinimumLength(3).WithMessage("Soyad yeri bos ola bilmez");
        }
    }
}
