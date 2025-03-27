using FluentValidation;

using Recipe.Application.EndPointModels;
using Recipe.Application.Validators.Constants;

namespace Recipe.Application.Validators;
public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(r => r.Login)
            .NotEmpty().WithMessage("Login is required")
            .MinimumLength(UserConstants.MinLengthLogin)
                .WithMessage($"Login minimum length is {UserConstants.MinLengthLogin}")
            .MaximumLength(UserConstants.MaxLengthLogin)
                .WithMessage($"Login maximum length is {UserConstants.MaxLengthLogin}");

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(UserConstants.MinLengthPassword)
                .WithMessage($"Password minimum length is {UserConstants.MinLengthPassword}");

        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Valid email is required");
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MaximumLength(UserConstants.MaxLengthFirstName)
                .WithMessage($"FirstName maximum length is {UserConstants.MaxLengthFirstName}");
        RuleFor(r => r.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .MaximumLength(UserConstants.MaxLengthLastName)
                .WithMessage($"LastName maximum length is {UserConstants.MaxLengthLastName}");
    }
}
