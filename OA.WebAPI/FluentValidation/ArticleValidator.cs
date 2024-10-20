using FluentValidation;
using OA.EntityLayer.Requests.ArticleRequests;

namespace OA.WebAPI.FluentValidation
{
	public class ArticleValidator : AbstractValidator<InsertArticleRequest>
	{
        public ArticleValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x=>x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.MainTitle)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MinimumLength(10).WithMessage("Title must be at least 10 characters long.")
                .MaximumLength(200).WithMessage("Title must be smaller than 200 characters long.");

			RuleFor(x => x.MainText)
				.NotEmpty().WithMessage("Content cannot be empty.")
				.MinimumLength(50).WithMessage("Content must be at least 50 characters long.")
				.MaximumLength(10000).WithMessage("Content must be smaller than 10000 characters long.");


			RuleFor(x => x.Summary)
					.NotEmpty().WithMessage("Summary cannot be empty.")
					.MinimumLength(10).WithMessage("Summary must be at least 10 characters long.")
					.MaximumLength(250).WithMessage("Summary must be smaller than 250 characters long.");

		}
	}
}
