using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
    [Table("ContactMessages")]
    public class ContactMessage
    {
        [Key]
        [Column("ContactMessageId")]
        public int ContactMessageId { get; set; }

        [Column("FullName")]
        public string? FullName { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Subject")]
        public string? Subject { get; set; }

        [Column("Message")]
        public string? Message { get; set; }

        [Column("SentDate")]
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        [Column("IsRead")]
        public bool IsRead { get; set; }
        
        [Column("Status")]
        public bool Status { get; set; }
    }
}
