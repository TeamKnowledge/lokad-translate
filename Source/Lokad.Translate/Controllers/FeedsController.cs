using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Autofac;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using NHibernate;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "Manager")]
    public class FeedsController : Controller
    {
    	readonly IFeedRepository Feeds;
		readonly IPageRepository Pages;

		public FeedsController()
			: this(GlobalSetup.Container.Resolve<IFeedRepository>(), GlobalSetup.Container.Resolve<IPageRepository>())
		{ }

		public FeedsController(IFeedRepository feedRepo, IPageRepository pageRepo)
		{
			Feeds = feedRepo;
			Pages = pageRepo;
		}

        //
        // GET: /Feeds/
        public ActionResult Index()
        {
            return View(Feeds.List());
        }

        //
        // GET: /Feeds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Feeds/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Feeds/Create
        [AcceptVerbs(HttpVerbs.Post)] 
		public ActionResult Create([Bind(Exclude = "Id")] Feed feed)
        {
			ValidateFeed(feed);

			if(!ModelState.IsValid)
			{
				return View();
			}

			Feeds.Create(feed);
			return RedirectToAction("Index", Feeds.List());
        }

        //
        // GET: /Feeds/Edit/5
        public ActionResult Edit(long id)
        {
            return View(Feeds.Edit(id));
        }

		//
		// GET: /Feeds/Edit/5
		public ActionResult Delete(long id)
		{
			Feeds.Delete(id);
			return RedirectToAction("Index", Feeds.List());
		}

        //
        // POST: /Feeds/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long id, Feed feed)
        {
			ValidateFeed(feed);

			if (!ModelState.IsValid)
			{
				return View();
			}

			Feeds.Edit(id, feed);
			return RedirectToAction("Index");
        }

		public ActionResult Refresh(long id)
		{
			var feedProcessor = GlobalSetup.Container.Resolve<FeedProcessor>();
			
			var updateCount = feedProcessor.ProcessFeed(id);

			ViewData["Message"] = 
				string.Format("{0} pages updated.", updateCount);

			return View("Index", Feeds.List());
		}

		void ValidateFeed(Feed feed)
		{
			if (string.IsNullOrEmpty(feed.Name))
			{
				ModelState.AddModelError("Name", "Name is required.", "");
			}

			if (!MvcHelpers.IsValidUri(feed.Url))
			{
				ModelState.AddModelError("Url", "Url is not valid.", "");
			}
		}
    }
}
