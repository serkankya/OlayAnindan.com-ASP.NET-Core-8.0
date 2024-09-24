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

        [Column("MainMediaPath")]
        public string? MainMediaPath { get; set; }

        [Column("MainMediaType")]
        public string? MainMediaType { get; set; }

		[Column("FirstMediaPath")]
		public string? FirstMediaPath { get; set; }

		[Column("FirstMediaType")]
		public string? FirstMediaType { get; set; }

		[Column("SecondMediaPath")]
		public string? SecondMediaPath { get; set; }

		[Column("SecondMediaType")]
		public string? SecondMediaType { get; set; }

		[Column("UploadedAt")]
        public DateTime UploadedAt { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
