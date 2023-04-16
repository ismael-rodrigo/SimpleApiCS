using FluentValidation;

namespace BaseApplicationModule.Domain.Entities.Shared.Username;

public class UsernameEntityValidator : AbstractValidator<UsernameEntity>
{
    public UsernameEntityValidator()
    {
        RuleFor(entity => entity.Value).NotEmpty().MinimumLength(6).MaximumLength(12);
    }
}