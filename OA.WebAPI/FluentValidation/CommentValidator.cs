using FluentValidation;
using OA.EntityLayer.Requests.CommentRequests;

namespace OA.WebAPI.FluentValidation
{
	public class CommentValidator : AbstractValidator<InsertCommentRequest>
	{
        public CommentValidator()
        {
            RuleFor(x => x.ArticleId)
                .GreaterThan(0);

            RuleFor(x=>x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.CommentText)
                .NotEmpty().WithMessage("Comment cannot be empty")
                .MaximumLength(250).WithMessage("Comment must be smaller than 250 characters.");
        }
    }
}
