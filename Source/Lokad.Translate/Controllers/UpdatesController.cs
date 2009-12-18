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
	[AuthorizeOrRedirect(Roles = "User")]
    public class UpdatesController : Controller
    {
		readonly UpdateRepository Updates = new UpdateRepository();
		readonly UserRepository Users = new UserRepository();

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
