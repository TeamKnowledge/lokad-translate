#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System;
using System.Linq;
using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[HandleErrorWithElmah]
	public class HomeController : Controller
	{
		readonly IUserRepository Users;

		public HomeController()
			: this(GlobalSetup.Container.Resolve<IUserRepository>())
		{ }

		public HomeController(IUserRepository userRepo)
		{
			Users = userRepo;
		}

		public ActionResult Index()
		{
			return View();
		}

		// exception thrown on purpose to check elmah
		public ActionResult Havoc()
		{
			throw new ArgumentException("on purpose");
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

		public ActionResult Error()
		{
			return View("Error");
		}
	}
}
