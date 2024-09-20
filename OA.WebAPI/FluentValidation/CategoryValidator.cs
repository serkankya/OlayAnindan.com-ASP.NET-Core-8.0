using FluentValidation;
using OA.EntityLayer.Requests.CategoryRequests;

namespace OA.WebAPI.FluentValidation
{
	public class CategoryValidator : AbstractValidator<InsertCategoryRequest>
	{
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .MinimumLength(4).WithMessage("Category name must be at least 4 characters.")
                .MaximumLength(75).WithMessage("Category name must be smaller than 75 characters.");

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Description cannot be empty.")
				.MinimumLength(20).WithMessage("Description must be at least 20 characters.")
				.MaximumLength(200).WithMessage("Description must be smaller than 200 characters.");

		}
	}
}
