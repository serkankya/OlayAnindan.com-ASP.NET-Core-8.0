using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Comments")]
	public class Comment
	{
        [Key]
        [Column("CommentId")]
        public int CommentId { get; set; }

        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("CommentText")]
        public string? CommentText { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
