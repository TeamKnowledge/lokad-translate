#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using Lokad.Translate.ViewModels;

namespace Lokad.Translate.Controllers
{
	[HandleErrorWithElmah]
	[AuthorizeOrRedirect(Roles = "User")]
    public class MapsController : Controller
    {
        const string ignoredUrlTemplate = "http://www.lokad.com/ignored.ashx";

		readonly ILangRepository Langs;
		readonly IMappingRepository Mappings;
		readonly IUpdateRepository Updates;
		readonly IUserRepository Users;
		readonly IRestRegexRepository Regexes;

		public MapsController()
			: this(GlobalSetup.Container.Resolve<ILangRepository>(), GlobalSetup.Container.Resolve<IMappingRepository>(),
				GlobalSetup.Container.Resolve<IUpdateRepository>(), GlobalSetup.Container.Resolve<IUserRepository>(),
				GlobalSetup.Container.Resolve<IRestRegexRepository>())
		{ }

		public MapsController(ILangRepository langRepo, IMappingRepository mappingRepo, IUpdateRepository updateRepo,
			IUserRepository userRepo, IRestRegexRepository regexRepo)
		{
			Langs = langRepo;
			Mappings = mappingRepo;
			Updates = updateRepo;
			Users = userRepo;
			Regexes = regexRepo;
		}

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
            var user = Users.Get(User.Identity.Name);

            var list = Mappings.List(id);

		    var model = new MappingListViewModel
		                    {
                                LanguageCode = id,
		                        Mappings = 
                                    list.Where(m => m.DestinationUrl != ignoredUrlTemplate)
                                    .ToList(),
		                        IgnoredMappings = 
                                    list
                                    .Where(m => user.IsManager 
                                        && m.DestinationUrl == ignoredUrlTemplate)
                                    .ToList()
		                    };

		    return user.IsManager? View("ManagerList",model): View(model);
		}

        public void IgnoreMappings(int [] itemIdList)
        {
            foreach (var id in itemIdList)
            {
                var mapping = Mappings.Edit(id);
                mapping.DestinationUrl = ignoredUrlTemplate;
                Mappings.Update(mapping);
            }
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
			ViewData["CodeUrl"] = CodeUrl(update.Page.Url);

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
			
			// HACK: CheckBox has a subtle behavior in ASP.NET MVC
			//var isUpdateComplete = form["IsUpdateComplete"].Contains("true"); 

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

		string CodeUrl(string url)
		{
			if (null == url) return null;

			return (from pattern in Regexes.ListCode()
			        let regex = new Regex(pattern.MatchRegex, RegexOptions.None)
			        let match = regex.Match(url)
			        where null != match
			        select match.Result(pattern.ReplaceRegex)).FirstOrDefault();
		}

		string EditUrl(string url)
		{
			if (null == url) return null;

			foreach(var pattern in Regexes.ListEdit())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if(null != match && match.Success)
				{
					return match.Result(pattern.ReplaceRegex);
				}
			}

			return null;
		}

		string HistoryUrl(string url)
		{
			if(null == url) return null;

			foreach (var pattern in Regexes.ListHistory())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if (null != match && match.Success)
				{
					return match.Result(pattern.ReplaceRegex);
				}
			}

			return null;
		}

		string DiffUrl(string url, string version)
		{
			if (null == url || null == version) return null;

			foreach (var pattern in Regexes.ListDiff())
			{
				var regex = new Regex(pattern.MatchRegex, RegexOptions.None);
				var match = regex.Match(url);

				if (null != match && match.Success)
				{
					return match.Result(pattern.ReplaceRegex).Replace("VERSION", version);
				}
			}

			return null;
		}
    }
}
