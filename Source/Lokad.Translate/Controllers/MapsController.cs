using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "User")]
    public class MapsController : Controller
    {
		readonly LangRepository Langs = new LangRepository();
		readonly MappingRepository Mappings = new MappingRepository();
		readonly UpdateRepository Updates = new UpdateRepository();
		readonly UserRepository Users = new UserRepository();
		readonly RestRegexRepository Regexes = new RestRegexRepository();

        //
        // GET: /Maps/
        public ActionResult Index()
        {
        	var user = Users.Get(User.Identity.Name);

			// displaying the list of available languages
			// if not default language is set for the user
			if (string.IsNullOrEmpty(user.Code))
			{
				return View(Langs.List());
			}
        	
			return RedirectToAction("List", new {id = user.Code});
        }

		//
		// GET: /Mappings/List/fr
		public ActionResult List(string id)
		{
			ViewData["LanguageCode"] = id;
			return View(Mappings.List(id));
		}

		// GET: /Mappings/Edit/5
		public ActionResult Edit(long id)
		{
			return View(Mappings.Edit(id));
		}

		//
		// POST: /Mappings/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long id, Mapping mapping)
		{
			var dbMapping = Mappings.Edit(id, mapping);
			return RedirectToAction("List", new {id = dbMapping.Code});
		}

		//
		// GET: /Mappings/Update/5
		public ActionResult Update(long id)
		{
			var update = Mappings.Edit(id);

			ViewData["EditUrl"] = EditUrl(update.DestinationUrl);
			ViewData["HistUrl"] = HistoryUrl(update.Page.Url);
			ViewData["DiffUrl"] = DiffUrl(update.Page.Url, update.Version);

			return View(update);
		}

		//
		// POST: /Mappings/Submit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Submit(long id, FormCollection form)
		{
			var destinationUrl = form["DestinationUrl"];
			var wordCount = int.Parse(form["WordCount"]);
			var version = form["Version"];

			var mapping = Mappings.Edit(id);

			if (wordCount < 0 && wordCount <= 10000)
			{
				ModelState.AddModelError("WordCount", "Word count should between 0 and 10000.", wordCount.ToString());
			}

			if (string.IsNullOrEmpty(version))
			{
				ModelState.AddModelError("Version", "Version is required.", "");
			}

			if(!string.IsNullOrEmpty((destinationUrl)))
			{
				mapping.DestinationUrl = destinationUrl;
			}
			else
			{
				if(string.IsNullOrEmpty(mapping.DestinationUrl))
				{
					ModelState.AddModelError("DestinationUrl", "Destination Url is required.", "");
				}
			}

			if(!ModelState.IsValid)
			{
				return View("Update", Mappings.Edit(id));
			}

			var user = Users.Get(User.Identity.Name);

			var update = new Update
			{
				User = user,
				WordCount = wordCount,
				Version = version,
				Mapping = mapping
			};

			mapping.Updates.Add(update);

			Updates.Create(update);

			mapping.Version = version;
			mapping.LastUpdated = DateTime.UtcNow;
			Mappings.Update(mapping);

			ViewData["Message"] = "Update recorded";
			return View("Update", Mappings.Edit(id));
		}

		//
		// GET: /Mappings/Next/5
		public ActionResult Next(long id)
		{
			return RedirectToAction("Update", new { id = Mappings.Next(id) });
		}

		string EditUrl(string url)
		{
			foreach(var pattern in Regexes.ListEdit())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if(null != match)
				{
					return match.Result(pattern.ReplaceRegex);
				}
			}

			return null;
		}

		string HistoryUrl(string url)
		{
			foreach (var pattern in Regexes.ListHistory())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if (null != match)
				{
					return match.Result(pattern.ReplaceRegex);
				}
			}

			return null;
		}

		string DiffUrl(string url, string version)
		{
			foreach (var pattern in Regexes.ListDiff())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if (null != match)
				{
					return match.Result(pattern.ReplaceRegex).Replace("VERSION", version);
				}
			}

			return null;
		}
    }
}