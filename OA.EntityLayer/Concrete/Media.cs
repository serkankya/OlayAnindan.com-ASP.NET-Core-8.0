using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Medias")]
	public class Media
	{
        [Key]
        [Column("MediaId")]
        public int MediaId { get; set; }

        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("FilePath")]
        public string? FilePath { get; set; }

        [Column("FileType")]
        public string? FileType { get; set; }

        [Column("AltText")]
        public string? AltText { get; set; }

        [Column("UploadedAt")]
        public DateTime UploadedAt { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
