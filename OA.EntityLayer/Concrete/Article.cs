using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Articles")]
	public class Article
	{
        [Key]
        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Column("Title")]
        public string? Title { get; set; }

        [Column("ContentText")]
        public string? ContentText { get; set; }

        [Column("Summary")]
        public string? Summary { get; set; }

        [Column("PublishedAt")]
        public DateTime PublishedAt { get; set; }

        [Column("ViewCount")]
        public int ViewCount { get; set; }
        [Column("IsMainNews")]
        public bool IsMainNews { get; set; }

        [Column("IsFeatured")]
        public bool IsFeatured { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
