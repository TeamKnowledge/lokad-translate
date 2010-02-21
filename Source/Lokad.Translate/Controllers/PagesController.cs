#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[HandleErrorWithElmah]
	[AuthorizeOrRedirect(Roles = "Manager")]
    public class PagesController : Controller
    {
		readonly IPageRepository _pages;
		readonly IMappingRepository _mappings; 

		public PagesController()
			: this(GlobalSetup.Container.Resolve<IPageRepository>(),
					GlobalSetup.Container.Resolve<IMappingRepository>())
		{ }

		public PagesController(IPageRepository pages, IMappingRepository mappings)
		{
			_pages = pages;
			_mappings = mappings;
		}

        //
        // GET: /Pages/
        public ActionResult Index()
        {
            return View(_pages.List());
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

			_pages.Create(page);
			return RedirectToAction("Index");
        }

        //
        // GET: /Pages/Edit/5
        public ActionResult Edit(long id)
        {
            return View(_pages.Edit(id));
        }

        //
        // POST: /Pages/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long id, Page page)
        {
			_pages.Edit(id, page);
			return RedirectToAction("Index");
        }

		//
		// GET: /Pages/Delete/5
		public ActionResult Delete(long id)
		{
			var page = _pages.Edit(id);
			ViewData["PageUrl"] = page.Url;
			return View(page.Mappings);
		}

		//
		// GET: /Pages/ConfirmDelete/5
		public ActionResult ConfirmDelete(long id)
		{
			try
			{
				_pages.Delete(id);
			}
			catch(InvalidOperationException)
			{
				var page = _pages.Edit(id);
				ViewData["PageUrl"] = page.Url;
				ViewData["Message"] = "Cannot delete page because updates are present.";

				return View("Delete", page.Mappings);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Mappings(long id)
		{
			var page = _pages.Edit(id);
			ViewData["PageUrl"] = page.Url;
			return View(page.Mappings);
		}

		public ActionResult CreateMappings(int id)
		{
			var processor = GlobalSetup.Container.Resolve<PageProcessor>();
			processor.ProcessPage(_pages.Edit(id));

			return RedirectToAction("Mappings", new { id = id });
		}

		public ActionResult DeleteMapping(long id)
		{
			var mapping = _mappings.Edit(id);
			var pageId = mapping.Page.Id;

			_mappings.Delete(id);

			return RedirectToAction("Mappings", new { id = pageId });
		}


		public ActionResult MarkAsUpdated(long id)
		{
			var page = _pages.Edit(id);
			page.LastUpdated = DateTime.UtcNow;
			_pages.Edit(id, page);

			return RedirectToAction("Index");
		}
    }
}
