using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Improve the webapp behavior by redirecting
	/// authorization failure toward the login page.</summary>
	public class AuthorizeOrRedirectAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			base.OnAuthorization(filterContext);

			if (filterContext.Result is HttpUnauthorizedResult)
			{
				filterContext.Result = 
					new RedirectResult("~/Account/Login?returnUrl=" + 
						HttpUtility.UrlEncode(filterContext.RequestContext.HttpContext.Request.Url.ToString()));
			}
		}
	}
}
