using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Concrete
{
	[Table("SocialMedias")]
	public class SocialMedia
	{
		[Key]
		[Column("SocialMediaId")]
		public int SocialMediaId { get; set; }

		[Column("Name")]
		public string? Name { get; set; }

		[Column("Icon")]
		public string? Icon { get; set; }

        [Column("BiggerIcon")]
        public string? BiggerIcon { get; set; }

        [Column("SiteUrl")]
		public string? SiteUrl { get; set; }

		[Column("Follower")]
		public int Follower { get; set; }

		[Column("CreatedAt")]
		public DateTime CreatedAt { get; set; }

		[Column("Status")]
		public bool Status { get; set; }

        [Column("LeftBackgroundColor")]
        public string? LeftBackgroundColor { get; set; }

        [Column("RightBackgroundColor")]
        public string? RightBackgroundColor { get; set; }
    }
}
