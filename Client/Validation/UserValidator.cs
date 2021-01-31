using FluentValidation;
using ReimaginedAdventure.Shared;

namespace ReimaginedAdventure.Client
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Handle).NotEmpty().Length(3,16);
        }
    }
}