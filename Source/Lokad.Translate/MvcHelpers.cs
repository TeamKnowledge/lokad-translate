#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Web.Mvc;

namespace Lokad.Translate
{
	public static class MvcHelpers
	{
		public static bool IsValidUri(string url)
		{
			Uri uri;
			return !string.IsNullOrEmpty(url) && Uri.TryCreate(url, UriKind.Absolute, out uri);
		}

		public static void AddModelError(
			this ModelStateDictionary modelState, string key, string errorMessage, string attemptedValue)
		{
			modelState.AddModelError(key, errorMessage);
			modelState.SetModelValue(key, new ValueProviderResult(attemptedValue, attemptedValue, null));
		}


		public static string CompactLink(this HtmlHelper helper, string url)
		{
			return String.Format("<a href=\"{0}\">{1}</a>", 
			                     url,
			                     url != null ? url.Replace("http://", "")
			                                   	.Replace("www.", "")
			                                   	.Replace(".aspx", "")
			                                   	.Replace(".ashx", "")
			                                   	.Replace(".html", "") : "");
		}

		/// <summary>Helper used to display a framed version of the source/target
		/// web pages (speeding-up translation works).</summary>
		public static string FrameView(this HtmlHelper helper, string label, string url)
		{
			if(string.IsNullOrEmpty(url)) return label;

			return String.Format(
				"<a onclick=\"javascript:document.getElementById('SideFrame').src = '{0}'\" href=\"#\">{1}</a>",
				url,
				label);
		}

		public static string SideView(this HtmlHelper helper, string label, string url)
		{
			if (string.IsNullOrEmpty(url)) return label;

			return String.Format("<a target=\"_lokadTranslate\" href=\"{0}\">{1}</a>", url, label);
		}
	}
}