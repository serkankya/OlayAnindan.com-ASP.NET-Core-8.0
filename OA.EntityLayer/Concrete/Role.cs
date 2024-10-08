﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

		[Column("Status")]
		public bool Status { get; set; }
	}
}
