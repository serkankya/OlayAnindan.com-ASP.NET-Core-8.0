using OA.EntityLayer.Requests.LoginRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BusinessLayer.Abstract
{
	public interface ILoginDal
	{
		Task<int> Login(LoginRequest loginRequest);
	}
}
