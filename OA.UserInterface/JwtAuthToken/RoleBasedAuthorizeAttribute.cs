using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class RoleBasedAuthorizeAttribute : ActionFilterAttribute
{
	private readonly int _requiredRoleId;

	public RoleBasedAuthorizeAttribute(int requiredRoleId)
	{
		_requiredRoleId = requiredRoleId;
	}

	public override void OnActionExecuting(ActionExecutingContext context)
	{
		var userRoleId = context.HttpContext.Items["ActiveRoleId"]?.ToString();

		if (userRoleId == null || int.Parse(userRoleId) != _requiredRoleId)
		{
			context.Result = new RedirectToActionResult("Error", "Home", new { area = "User" });
		}

		base.OnActionExecuting(context);
	}
}
