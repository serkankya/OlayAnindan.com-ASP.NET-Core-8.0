using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Tags")]
	public class Tag
	{
		[Key]
		[Column("TagId")]
		public int TagId { get; set; }

		[Column("TagName")]
		public string? TagName { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
