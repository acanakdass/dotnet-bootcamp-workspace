using AspectOriented.Entities;
using FluentValidation;

namespace AspectOriented.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(c => c.Firstname).NotEmpty();
        RuleFor(c => c.Lastname).NotEmpty();
        RuleFor(c => c.Email).MinimumLength(10).EmailAddress();
    }
}