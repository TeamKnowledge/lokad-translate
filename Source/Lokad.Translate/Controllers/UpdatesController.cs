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
	[AuthorizeOrRedirect(Roles = "User")]
    public class UpdatesController : Controller
    {
		readonly IUpdateRepository _updates;
		readonly IUserRepository _users;

		public UpdatesController()
			: this(GlobalSetup.Container.Resolve<IUpdateRepository>(), GlobalSetup.Container.Resolve<IUserRepository>())
		{ }

		public UpdatesController(IUpdateRepository updates, IUserRepository users)
		{
			_updates = updates;
			_users = users;
		}

        public ActionResult Index()
        {
			// returning all updates to admins
			if (User.IsInRole("Manager"))
			{
				return View(_updates.ListNotBatched());
			}

			// else returning only user updates
        	return View(_updates.ListNotBatched(_users.Get(User.Identity.Name).Id));
        }

		public ActionResult All()
		{
			// returning all updates to admins
			if (User.IsInRole("Manager"))
			{
				return View("Index", _updates.List());
			}

			// else returning only user updates
			return View("Index", _updates.List(_users.Get(User.Identity.Name).Id));
		}

		public ActionResult Delete(long id)
		{
			// non-admin could only delete their own logs
			if (!User.IsInRole("Manager"))
			{
				var update = _updates.Edit(id);
				var user = _users.Get(User.Identity.Name);

				if(user.Id != update.User.Id)
				{
					return RedirectToAction("Index", _updates.List());
				}
			}

			_updates.Delete(id);
			return RedirectToAction("Index", _updates.List());
		}
    }
}
