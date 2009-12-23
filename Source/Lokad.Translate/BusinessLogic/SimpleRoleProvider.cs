using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lokad.Translate.Repositories;
using Autofac;
using Lokad.Translate.Entities;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Minimal role implementation. Roles are defined
	/// based on the <c>User</c> table. Only 1 role is available:
	/// <c>Manager</c>.</summary>
	public class SimpleRoleProvider : RoleProvider
	{
		// Note on the implementation: SimpleRoleProvider is a singleton managed by the .NET runtime
		// All ISession objects are managed on a per-request basis, meaning that this component
		// needs a fresh ISession every time it's called, thus the need to directly inject IContainer
		// AND create an inner container, disposed immediately.

		readonly IContainer _container;

		public SimpleRoleProvider()
			: this(GlobalSetup.Container)
		{ }

		public SimpleRoleProvider(IContainer container)
		{
			_container = container;
		}

		public override string[] GetRolesForUser(string username)
		{
			User user;
			using(var inner = _container.CreateInnerContainer())
			{
				user = inner.Resolve<IUserRepository>().Get(username);
			}
			
			// no role if user is not registered
			if(null == user) return new string[0];

			// default role for registered user
			return user.IsManager ? new[] { "Manager", "User" } : new[] { "User" };
		}

		public override bool IsUserInRole(string username, string roleName)
		{
			if("Manager" != roleName) return false;

			User user;
			using(var inner = _container.CreateInnerContainer())
			{
				user = inner.Resolve<IUserRepository>().Get(username);
			}
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
