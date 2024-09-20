using FluentValidation;
using OA.EntityLayer.Requests.UserRequests;

namespace OA.WebAPI.FluentValidation
{
	public class UserValidator : AbstractValidator<InsertUserRequest>
	{
		public UserValidator()
		{
			RuleFor(x => x.RoleId).
				GreaterThan(0).WithMessage("You have to choose a role.");

			RuleFor(x => x.Username).
				NotEmpty().WithMessage("Username cannot be empty.")
				.MinimumLength(2).WithMessage("Username must be at least 2 characters long.")
				.MaximumLength(75).WithMessage("Username must be smaller than 75 characters long.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email cannot be empty.")
				.MinimumLength(10).WithMessage("Email must be at least 10 characters long.")
				.MaximumLength(175).WithMessage("Email must be smaller than 175 characters long.");

			RuleFor(x => x.PasswordHash)
				 .NotEmpty().WithMessage("Password cannot be empty.")
				 .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
				 .MaximumLength(50).WithMessage("Password must be smaller than 50 characters long.")
				 .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)").WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");

			RuleFor(x => x.FullName)
				.NotEmpty().WithMessage("Full name cannot be empty.")
				.MinimumLength(4).WithMessage("Full name must be at least 4 characters long.")
				.MaximumLength(100).WithMessage("Full name must be smaller than 100 characters long");
		}
	}
}
