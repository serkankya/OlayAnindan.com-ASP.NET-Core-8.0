using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Categories")]
	public class Category
	{
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Column("CategoryName")]
        public string? CategoryName { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
