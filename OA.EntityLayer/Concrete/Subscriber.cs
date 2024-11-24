using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Subscribers")]
	public class Subscriber
	{
        [Key]
        [Column("SubscriberId")]
        public int SubscriberId { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("RemovedAt")]
        public DateTime RemovedAt { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
