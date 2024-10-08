﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.EntityLayer.Concrete
{
	[Table("Users")]
	public class User
	{
		[Key]
		[Column("UserId")]
		public int UserId { get; set; }

		[Column("RoleId")]
		public int RoleId { get; set; }

		[Column("Username")]
		public string? Username { get; set; }

		[Column("PasswordHash")]
		public string? PasswordHash { get; set; }

		[Column("Email")]
		public string? Email { get; set; }

		[Column("Biography")]
		public string? Biography { get; set; }

		[Column("FullName")]
		public string? FullName { get; set; }

		[Column("ImageUrl")]
		public string? ImageUrl { get; set; }

		[Column("CreatedAt")]
		public DateTime CreatedAt { get; set; }

		[Column("UpdatedAt")]
		public DateTime UpdatedAt { get; set; }

		[Column("Status")]
		public bool Status { get; set; }

		[Column("LastLogin")]
		public DateTime LastLogin { get; set; }
	}
}
