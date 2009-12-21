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
		readonly IUserRepository Users;
		readonly IFeedRepository Feeds;
		readonly IPageRepository Pages;
		readonly ILangRepository Langs;
		readonly IMappingRepository Mappings;

		public HomeController()
			: this(GlobalSetup.Container.Resolve<IUserRepository>(), GlobalSetup.Container.Resolve<IFeedRepository>(),
				GlobalSetup.Container.Resolve<IPageRepository>(), GlobalSetup.Container.Resolve<ILangRepository>(),
				GlobalSetup.Container.Resolve<IMappingRepository>())
		{ }

		public HomeController(IUserRepository userRepo, IFeedRepository feedRepo, IPageRepository pageRepo,
			ILangRepository langRepo, IMappingRepository mappingRepo)
		{
			Users = userRepo;
			Feeds = feedRepo;
			Pages = pageRepo;
			Langs = langRepo;
			Mappings = mappingRepo;
		}

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
			var feedProc = GlobalSetup.Container.Resolve<FeedProcessor>();
			var pageProc = GlobalSetup.Container.Resolve<PageProcessor>();

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
