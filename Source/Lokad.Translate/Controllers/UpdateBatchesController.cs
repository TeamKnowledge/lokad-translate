using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "Manager, User")]
    public class UpdateBatchesController : Controller
    {
		readonly UpdateBatchRepository Batches = new UpdateBatchRepository();

        //
        // GET: /UpdateBatches/
        public ActionResult Index()
        {
            return View(Batches.List());
        }

		//
		// GET: /UpdateBatches/Create
		public ActionResult Create()
		{
			return View(Batches.Pending());
		}

		//
		// GET: /UpdateBatches/Create/is
		public ActionResult ConfirmCreate(long id)
		{
			Batches.CreateBatch(id);
			return RedirectToAction("Index");
		}

		//
		// GET: /UpdateBatches/Details/5
		public ActionResult Details(long id)
		{
			var batch = Batches.Get(id);
			ViewData["BatchId"] = batch.Id;
			ViewData["Translator"] = batch.User.DisplayName;
			ViewData["WordCount"] = batch.WordCount;
			ViewData["IsPaid"] = batch.IsPaid;

			return View(batch.Updates);
		}

		public ActionResult ToggleIsPaid(long id)
		{
			var batch = Batches.ToggleIsPaid(id);

			ViewData["BatchId"] = batch.Id;
			ViewData["Translator"] = batch.User.DisplayName;
			ViewData["WordCount"] = batch.WordCount;
			ViewData["IsPaid"] = batch.IsPaid;

			return View("Details", batch.Updates);
		}
    }
}
