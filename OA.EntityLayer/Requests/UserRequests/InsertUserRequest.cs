using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.UserRequests
{
	public record InsertUserRequest(int RoleId, string Username, string PasswordHash, string Email, string Biography, string FullName, string ImageUrl);
}
