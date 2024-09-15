using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column("FileSize")]
        public int FileSize { get; set; }

        [Column("UploadedAt")]
        public DateTime UploadedAt { get; set; }
    }
}
