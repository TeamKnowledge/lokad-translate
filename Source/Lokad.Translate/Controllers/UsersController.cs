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
    public class UsersController : Controller
    {
		readonly IUserRepository Users;

		public UsersController()
			: this(GlobalSetup.Container.Resolve<IUserRepository>())
		{ }

		public UsersController(IUserRepository userRepo)
		{
			Users = userRepo;
		}

        //
        // GET: /Users/
        public ActionResult Index()
        {
            return View(Users.List());
        }

		// 
		// GET: /Users/Edit/5
		public ActionResult Edit(long id)
		{
			return View(Users.Edit(id));
		}

		//
		// POST: /Feeds/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long id, User user)
		{
			ValidateUser(user);

			if (!ModelState.IsValid)
			{
				return View(user);
			}

			Users.Edit(id, user);
			return RedirectToAction("Index");
		}

		//
		// GET: /Users/Create
		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Users/Create
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create([Bind(Exclude = "Id")] User user)
		{
			ValidateUser(user);

			if (!ModelState.IsValid)
			{
				return View(user);
			}

			Users.Create(user);
			return RedirectToAction("Index", Users.List());
		}

		//
		// GET: /Feeds/Edit/5
		public ActionResult Delete(long id)
		{
			Users.Delete(id);
			return RedirectToAction("Index", Users.List());
		}

		void ValidateUser(User user)
		{
			if (string.IsNullOrEmpty(user.DisplayName))
			{
				ModelState.AddModelError("Display Name", "Display name is required.", "");
			}

			if (!MvcHelpers.IsValidUri(user.OpenId))
			{
				ModelState.AddModelError("OpenId", "OpenId is not a valid URL.", "");
			}
		}
    }
}
