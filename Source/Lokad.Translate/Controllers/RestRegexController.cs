using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "Manager, User")]
    public class RestRegexController : Controller
    {
		readonly RestRegexRepository Regexes = new RestRegexRepository();

        public ActionResult Index()
        {
            return View(Regexes.List());
        }

		public ActionResult Create()
		{
			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create([Bind(Exclude = "Id")] RestRegex regex)
		{
			ValidateRestRegex(regex);

			if (!ModelState.IsValid)
			{
				return View();
			}

			Regexes.Create(regex);
			return RedirectToAction("Index", Regexes.List());
		}

		public ActionResult Edit(long id)
		{
			return View(Regexes.Edit(id));
		}

		//
		// POST: /Feeds/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long id, RestRegex feed)
		{
			ValidateRestRegex(feed);

			if (!ModelState.IsValid)
			{
				return View();
			}

			Regexes.Edit(id, feed);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(long id)
		{
			Regexes.Delete(id);
			return RedirectToAction("Index");
		}

		private void ValidateRestRegex(RestRegex regex)
		{
			if (string.IsNullOrEmpty(regex.Name))
			{
				ModelState.AddModelError("Name", "Name is required.", "");
			}

			if (string.IsNullOrEmpty(regex.MatchRegex))
			{
				ModelState.AddModelError("MatchRegex", "Match Regex is required.", "");
			}

			if (string.IsNullOrEmpty(regex.ReplaceRegex))
			{
				ModelState.AddModelError("ReplaceRegex", "Replace Regex is required.", "");
			}

			if(!(regex.IsDiff || regex.IsEdit || regex.IsHistory))
			{
				ModelState.AddModelError("IsDiff", "At least one version must be checked.", "");

			}
		}

		public ActionResult SetupForScrewTurn()
		{
			var edit = new RestRegex
			{
				Name = "ScrewTurn Wiki Edit",
				IsEdit = true,
				MatchRegex = @"^(http|https)://((.)+)/((.)+).ashx",
				ReplaceRegex = @"$1://$2/Edit.aspx?Page=$4"
			};

			var hist = new RestRegex
			{
				Name = "ScrewTurn Wiki History",
				IsHistory = true,
				MatchRegex = @"^(http|https)://((.)+)/((.)+).ashx",
				ReplaceRegex = @"$1://$2/History.aspx?Page=$4"
			};

			var diff = new RestRegex
           	{
           		Name = "ScrewTurn Wiki Diff",
           		IsDiff = true,
				MatchRegex = @"^(http|https)://((.)+)/((.)+).ashx",
				ReplaceRegex = "$1://$2/Diff.aspx?Page=$4&Rev1=VERSION&Rev2=Current"
           	};

			Regexes.Create(diff);
			Regexes.Create(hist);
			Regexes.Create(edit);

			return RedirectToAction("Index");
		}
    }
}
