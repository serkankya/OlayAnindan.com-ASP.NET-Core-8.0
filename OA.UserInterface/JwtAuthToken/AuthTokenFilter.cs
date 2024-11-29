using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OA.EntityLayer.Requests.UserRequests;
using OA.UserInterface.Models;
using System.IdentityModel.Tokens.Jwt;

public class AuthTokenFilter : ActionFilterAttribute
{
	public async override void OnActionExecuting(ActionExecutingContext context)
	{
		var token = context.HttpContext.Request.Cookies["AuthToken"];

		if (string.IsNullOrEmpty(token))
		{
			context.HttpContext.Items["ActiveUserId"] = null;
		}
		else
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			if (token.StartsWith("Bearer ", StringComparison.InvariantCultureIgnoreCase))
			{
				token = token.Substring("Bearer ".Length);
			}

			try
			{
				var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

				if (jwtToken != null)
				{
					var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
					context.HttpContext.Items["ActiveUserId"] = userId;
				}
				else
				{
					context.HttpContext.Items["ActiveUserId"] = null; 
				}
			}
			catch
			{
				context.HttpContext.Items["ActiveUserId"] = null; 
			}
		}

		base.OnActionExecuting(context);
	}
}
