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
		readonly UserRepository Users = new UserRepository();

		public override string[] GetRolesForUser(string username)
		{
			var user = Users.Get(username);
			
			// no role if user is not registered
			if(null == user) return new string[0];

			// default role for registered user
			return user.IsManager ? new[] { "Manager", "User" } : new[] { "User" };
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			if("Manager" != roleName) return false;
			
			var user = Users.Get(username);
			return user.IsManager;
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
