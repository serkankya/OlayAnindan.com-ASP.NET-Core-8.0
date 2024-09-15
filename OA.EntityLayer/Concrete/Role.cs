using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Concrete
{
	[Table("Roles")]
	public class Role
	{
        [Key]
        [Column("RoleId")]
        public int RoleId { get; set; }

        [Column("RoleName")]
        public string? RoleName { get; set; }

        [Column("Description")]
        public string? Description { get; set; }
    }
}
