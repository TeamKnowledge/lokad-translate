using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		// HACK: Inits would need to be migrated toward IoC
		readonly UserRepository Users = new UserRepository();
		readonly FeedRepository Feeds = new FeedRepository();
		readonly PageRepository Pages = new PageRepository();
		readonly LangRepository Langs = new LangRepository();
		readonly MappingRepository Mappings = new MappingRepository();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Manage()
		{
			return View();
		}

		/// <summary>Hack: coupling this controller with a web CRON job 
		/// (see http://setcronjob.com) to update the content of the pages.
		/// </summary>
		public ActionResult Cron()
		{
			var feedProc = new FeedProcessor(Feeds, Pages);
			var pageProc = new PageProcessor(Pages, Langs, Mappings);

			ViewData["PagesRefreshed"] = feedProc.ProcessAll();
			ViewData["MappingsInserted"] = pageProc.ProcessAll();
			return View();
		}

		public ActionResult Setup()
		{
			if(Users.List().Any())
			{
				ViewData["SetupMessage"] = "The setup has already been performed.";	
			}

			return View();
		}

		[AuthorizeOrRedirect]
		public ActionResult ConfirmSetup()
		{
			if (!Users.List().Any())
			{
				Users.Create(new User
				             	{
				             		DisplayName = User.Identity.Name, 
									OpenId = User.Identity.Name, 
									IsManager = true
				             	});
			}

			return RedirectToAction("Setup");
		}
	}
}
