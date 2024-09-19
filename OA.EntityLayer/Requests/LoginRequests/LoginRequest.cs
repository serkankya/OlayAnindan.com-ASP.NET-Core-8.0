using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Requests.LoginRequests
{
    public record LoginRequest(string Username, string PasswordHash);
}
