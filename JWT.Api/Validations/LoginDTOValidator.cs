using FluentValidation;
using JWT.Api.DTOs;

namespace JWT.Api.Validations
{
    public class LoginDTOValidator:AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(p => p.UsernameOrEmail).MinimumLength(3).WithMessage("Uzunlugu en az 3 olsun");
        }
    }
}
