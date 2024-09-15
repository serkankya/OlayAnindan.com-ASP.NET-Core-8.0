using Microsoft.Extensions.Options;
using OA.BusinessLayer.Abstract.Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DataAccessLayer.Concrete.Dapper
{
	public class DapperContext : IDapperContext
	{
		private readonly ContextOption _contextOption;

		public DapperContext(IOptions<ContextOption> contextOption)
		{
			_contextOption = contextOption.Value;
		}

		public SqlConnection GetConnection()
		{
			return new SqlConnection(_contextOption.connection);
		}
	}
}
