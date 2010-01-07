#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Lokad.Translate.Controllers
{
	[HandleError]
	public class AccountController : Controller
	{
		private static readonly OpenIdRelyingParty OpenId = new OpenIdRelyingParty();

		public ActionResult Login()
		{
			return View();
		}

		public ActionResult Authenticate(string returnUrl)
		{
			var response = OpenId.GetResponse();

			if (response == null)
			{
				// Stage 2: user submitting Identifier
				Identifier id;
				if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
				{
					OpenId.CreateRequest(Request.Form["openid_identifier"]).RedirectToProvider();
				}
				else
				{
					ViewData["Message"] = "Invalid identifier";
					return View("Login");
				}
			}
			else
			{
				// Stage 3: OpenID Provider sending assertion response
				switch (response.Status)
				{
					case AuthenticationStatus.Authenticated:
						Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
						FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
						if (!string.IsNullOrEmpty(returnUrl))
						{
							return Redirect(returnUrl);
						}
						else
						{
							return RedirectToAction("Index", "Home");
						}
					case AuthenticationStatus.Canceled:
						ViewData["Message"] = "Canceled at provider";
						return View("Login");
					case AuthenticationStatus.Failed:
						ViewData["Message"] = response.Exception.Message;
						return View("Login");
				}
			}
			return new EmptyResult();
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}
