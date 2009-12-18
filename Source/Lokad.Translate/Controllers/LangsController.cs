using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "Manager, User")]
    public class LangsController : Controller
    {
		readonly LangRepository Repository = new LangRepository();

        //
        // GET: /Langs/
        public ActionResult Index()
        {
            return View(Repository.List());
        }

        //
        // GET: /Langs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Langs/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Langs/Create
        [AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create([Bind(Exclude = "Id")] Lang lang)
        {
			Repository.Create(lang);
			return RedirectToAction("Index");
        }

        //
        // GET: /Langs/Edit/5
        public ActionResult Edit(long id)
        {
            return View(Repository.Edit(id));
        }

		//
		// GET: /Langs/Delete/5
		public ActionResult Delete(long id)
		{
			Repository.Delete(id);
			return RedirectToAction("Index");
		}

        //
        // POST: /Langs/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(long id, Lang lang)
        {
			Repository.Edit(id, lang);
			return RedirectToAction("Index");
        }
    }
}
