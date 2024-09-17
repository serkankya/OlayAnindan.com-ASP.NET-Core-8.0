using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Notifications")]
	public class Notification
	{
        [Key]
        [Column("NotificationId")]
        public int NotificationId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Message")]
        public string? Message { get; set; }

        [Column("IsRead")]
        public bool IsRead { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
