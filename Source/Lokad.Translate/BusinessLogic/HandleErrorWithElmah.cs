using System;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace Lokad.Translate.BusinessLogic
{
	// code reclycled from 
	// http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute
	public class HandleErrorWithElmahAttribute : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);
			if (context.ExceptionHandled)
				RaiseErrorSignal(context.Exception);
		}

		private static void RaiseErrorSignal(Exception e)
		{
			var context = HttpContext.Current;
			ErrorSignal.FromContext(context).Raise(e, context);
		}
	}
}
