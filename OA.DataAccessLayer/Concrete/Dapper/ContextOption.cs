using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DataAccessLayer.Concrete.Dapper
{
	public class ContextOption
	{
		public const string ConnectionString = "ConnectionStrings";

		public string? connection { get; set; } = string.Empty;
	}
}
