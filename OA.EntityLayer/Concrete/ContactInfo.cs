using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
    [Table("ContactInfos")]
    public class ContactInfo
    {
        [Key]
        [Column("ContactInfoId")]
        public int ContactInfoId { get; set; }

        [Column("Info")]
        public string? Info { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("Status")]
        public bool Status { get; set; }
    }
}
