using FluentValidation;
using OA.EntityLayer.Requests.RoleRequests;

namespace OA.WebAPI.FluentValidation
{
	public class RoleValidator : AbstractValidator<InsertRoleRequest>
	{
        public RoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Role name cannot be empty.")
                .MinimumLength(3).WithMessage("Role name must be at least 2 characters long.")
                .MaximumLength(75).WithMessage("Role name must be smaller than 75 characters long.");

            RuleFor(x => x.Description)
                .MinimumLength(20).WithMessage("Description must be at least 20 characters long")
                .MaximumLength(200).WithMessage("Description must be smaller than 200 characters long.");
        }
    }
}
