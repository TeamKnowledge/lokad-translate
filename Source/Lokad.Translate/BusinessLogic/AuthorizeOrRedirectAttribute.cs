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
				// do not use 'filterContext.RequestContext.HttpContext.Request.Url' because of Azure port forwarding
				// http://social.msdn.microsoft.com/Forums/en-US/windowsazure/thread/9142db8d-0f85-47a2-91f7-418bb5a0c675/

				var scheme = filterContext.RequestContext.HttpContext.Request.Url.Scheme;
				var host = filterContext.RequestContext.HttpContext.Request.Headers["Host"];
				var path = filterContext.RequestContext.HttpContext.Request.RawUrl;
				var returnUrl = scheme + @"://" + host + path;

				filterContext.Result =
					new RedirectResult("~/Account/Login?returnUrl=" + HttpUtility.UrlEncode(returnUrl));
			}
		}
	}
}
