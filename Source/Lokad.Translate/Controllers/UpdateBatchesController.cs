#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[HandleErrorWithElmah]
	[AuthorizeOrRedirect(Roles = "Manager, User")]
    public class UpdateBatchesController : Controller
    {
		readonly IUpdateBatchRepository Batches;

		public UpdateBatchesController()
			: this(GlobalSetup.Container.Resolve<IUpdateBatchRepository>())
		{ }

		public UpdateBatchesController(IUpdateBatchRepository batchRepo)
		{
			Batches = batchRepo;
		}

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
