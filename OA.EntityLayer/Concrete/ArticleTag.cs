using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("ArticleTags")]
	public class ArticleTag
	{
        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("TagId")]
        public int TagId { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
