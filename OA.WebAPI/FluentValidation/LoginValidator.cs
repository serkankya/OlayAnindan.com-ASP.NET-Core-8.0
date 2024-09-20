using FluentValidation;
using OA.EntityLayer.Requests.LoginRequests;

namespace OA.WebAPI.FluentValidation
{
	public class LoginValidator : AbstractValidator<LoginRequest>
	{
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
