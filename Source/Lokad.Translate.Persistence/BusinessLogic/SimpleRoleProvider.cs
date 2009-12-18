using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Minimal role implementation. Roles are defined
	/// based on the <c>User</c> table. Only 1 role is available:
	/// <c>Manager</c>.</summary>
	public class SimpleRoleProvider : RoleProvider 
	{
		// isolated session management for the RoleProvider to avoid
		// issues with automated management of session lifecycle.

		public override string[] GetRolesForUser(string username)
		{
			try
			{
				using (var session = GlobalSetup.SessionFactory.OpenSession())
				{
					var users = new UserRepository(session);
					var user = users.Get(username);

					// no role if user is not registered
					if (null == user) return new string[0];

					// default role for registered user
					return user.IsManager ? new[] {"Manager", "User"} : new[] {"User"};
				}

			}
			// TODO: exception is not be left un-processed
			catch (Exception)
			{
				// role should not fail in case of DB issue.
				return new string[0];
			}
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			if("Manager" != roleName && "User" != roleName) return false;

			try
			{
				using (var session = GlobalSetup.SessionFactory.OpenSession())
				{
					var users = new UserRepository(session);
					var user = users.Get(username);

					if (null == user) return false;

					return (user.IsManager && "Manager" == roleName) || ("User" == roleName);
				}
			}
			catch (Exception) // TODO: exception is not be left un-processed
			{
				// role should not fail in case of DB issue.
				return false;
			}
			
		}

		public override void CreateRole(string roleName)
		{
			throw new NotSupportedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotSupportedException();
		}

		public override bool RoleExists(string roleName)
		{
			throw new NotSupportedException();
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			throw new NotSupportedException();
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			throw new NotSupportedException();
		}

		public override string[] GetUsersInRole(string roleName)
		{
			throw new NotSupportedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotSupportedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotSupportedException();
		}

		public override string ApplicationName
		{
			get { return "Lokad.Translate"; }
			set { throw new NotSupportedException(); }
		}
	}
}
