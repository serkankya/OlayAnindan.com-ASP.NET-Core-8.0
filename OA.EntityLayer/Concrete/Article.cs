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

        [Column("MainTitle")]
        public string? MainTitle { get; set; }

        [Column("MainText")]
        public string? MainText { get; set; }

        [Column("FirstTitle")]
        public string? FirstTitle { get; set; }

        [Column("FirstText")]
        public string? FirstText { get; set; }

        [Column("SecondTitle")]
        public string? SecondTitle { get; set; }

        [Column("SecondText")]
        public string? SecondText { get; set; }

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
