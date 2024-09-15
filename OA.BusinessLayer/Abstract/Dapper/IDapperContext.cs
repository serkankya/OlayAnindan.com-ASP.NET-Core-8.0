using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BusinessLayer.Abstract.Dapper
{
	public interface IDapperContext
	{
		SqlConnection GetConnection();
	}
}
