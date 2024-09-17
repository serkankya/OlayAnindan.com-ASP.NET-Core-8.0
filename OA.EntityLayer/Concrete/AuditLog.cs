using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Concrete
{
	[Table("AuditLogs")]
	public class AuditLog
	{
		[Key]
		[Column("LogId")]
        public int LogId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Action")]
        public string? Action { get; set; }

        [Column("ActionDate")]
        public DateTime ActionDate { get; set; }

		[Column("Status")]
		public bool Status { get; set; }
	}
}
