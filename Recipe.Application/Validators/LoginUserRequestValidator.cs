using FluentValidation;

using Recipe.Application.EndPointModels;

namespace Recipe.Application.Validators;

public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        RuleFor(l => l.Login)
            .NotEmpty().WithMessage("Login is required");
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
