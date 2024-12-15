using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Ads")]
	public class Ad
	{
        [Key]
        [Column("AdsId")]
        public int AdsId { get; set; }

        [Column("CompanyName")]
        public string? CompanyName { get; set; }

        [Column("CompanyWebsite")]
        public string? CompanyWebsite { get; set; }

        [Column("AdsUrl")]
        public string? AdsUrl { get; set; }

        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
