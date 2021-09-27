using System.Drawing;
using FluentValidation;
using ReimaginedAdventure.Shared;

namespace ReimaginedAdventure.Client
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Handle)
                .NotEmpty()
                .Length(3,16);

            RuleFor(u => u.Color)
                .NotEmpty()
                .Must(BeValidColor)
                .WithMessage("Please select a color");
        }

        private bool BeValidColor(string arg)
        {
            try
            {
                ColorTranslator.FromHtml(arg);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
