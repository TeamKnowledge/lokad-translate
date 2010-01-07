#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System.Web.Mvc;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.Controllers
{
	[AuthorizeOrRedirect(Roles = "User")]
    public class UpdatesController : Controller
    {
		readonly IUpdateRepository Updates;
		readonly IUserRepository Users;

		public UpdatesController()
			: this(GlobalSetup.Container.Resolve<IUpdateRepository>(), GlobalSetup.Container.Resolve<IUserRepository>())
		{ }

		public UpdatesController(IUpdateRepository updateRepo, IUserRepository userRepo)
		{
			Updates = updateRepo;
			Users = userRepo;
		}

        //
        // GET: /Updates/
        public ActionResult Index()
        {
			// returning all updates to admins
			if (User.IsInRole("Manager"))
			{
				return View(Updates.List());
			}

			// else returning only user updates
        	return View(Updates.List(Users.Get(User.Identity.Name).Id));
        }

		//
		// GET: /Updates/Delete/5
		public ActionResult Delete(long id)
		{
			// non-admin could only delete their own logs
			if (!User.IsInRole("Manager"))
			{
				var update = Updates.Edit(id);
				var user = Users.Get(User.Identity.Name);

				if(user.Id != update.User.Id)
				{
					return RedirectToAction("Index", Updates.List());
				}
			}

			Updates.Delete(id);
			return RedirectToAction("Index", Updates.List());
		}
    }
}
