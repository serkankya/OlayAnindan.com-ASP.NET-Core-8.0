using FluentValidation;
using OA.EntityLayer.Requests.TagRequests;

namespace OA.WebAPI.FluentValidation
{
	public class TagValidator : AbstractValidator<InsertTagRequest>
	{
        public TagValidator()
        {
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("Tag cannot be empty.")
                .MinimumLength(2).WithMessage("Tag must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Tag must be smaller than 50 characters long.");
        }
    }
}
