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

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "Manager, User")]
    public class PagesController : Controller
    {
		readonly IPageRepository Pages;

		public PagesController()
			: this(GlobalSetup.Container.Resolve<IPageRepository>())
		{ }

		public PagesController(IPageRepository pageRepo)
		{
			Pages = pageRepo;
		}

        //
        // GET: /Pages/
        public ActionResult Index()
        {
            return View(Pages.List());
        }

        //
        // GET: /Pages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /Pages/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] Page page)
        {
			if(!MvcHelpers.IsValidUri(page.Url))
			{
				ModelState.AddModelError("Url", "Url is not valid.", "");
			}

			if(!ModelState.IsValid)
			{
				return View();
			}

			Pages.Create(page);
			return RedirectToAction("Index");
        }

        //
        // GET: /Pages/Edit/5
        public ActionResult Edit(long id)
        {
            return View(Pages.Edit(id));
        }

        //
        // POST: /Pages/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long id, Page page)
        {
			Pages.Edit(id, page);
			return RedirectToAction("Index");
        }

		//
		// GET: /Pages/Delete/5
		public ActionResult Delete(long id)
		{
			var page = Pages.Edit(id);
			ViewData["PageUrl"] = page.Url;
			return View(page.Mappings);
		}

		//
		// GET: /Pages/ConfirmDelete/5
		public ActionResult ConfirmDelete(long id)
		{
			try
			{
				Pages.Delete(id);
			}
			catch(InvalidOperationException)
			{
				var page = Pages.Edit(id);
				ViewData["PageUrl"] = page.Url;
				ViewData["Message"] = "Cannot delete page because updates are present.";

				return View("Delete", page.Mappings);
			}

			return RedirectToAction("Index");
		}

		//
		// GET: /Pages/Mappings/5
		public ActionResult Mappings(long id)
		{
			var page = Pages.Edit(id);
			ViewData["PageUrl"] = page.Url;
			return View(page.Mappings);
		}


		//
		// GET: /Pages/MarkAsUpdated/5
		public ActionResult MarkAsUpdated(long id)
		{
			var page = Pages.Edit(id);
			page.LastUpdated = DateTime.UtcNow;
			Pages.Save(page);

			return RedirectToAction("Index");
		}
    }
}
