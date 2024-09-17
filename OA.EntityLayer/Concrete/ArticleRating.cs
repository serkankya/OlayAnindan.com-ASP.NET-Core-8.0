using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("ArticleRatings")]
	public class ArticleRating
	{
		[Key]
		[Column("RatingId")]
		public int RatingId { get; set; }

		[Column("ArticleId")]
		public int ArticleId { get; set; }

		[Column("UserId")]
		public int UserId { get; set; }

		[Column("RatingValue")]
		public Int16 RatingValue { get; set; }

		[Column("CreatedAt")]
		public DateTime CreatedAt { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
