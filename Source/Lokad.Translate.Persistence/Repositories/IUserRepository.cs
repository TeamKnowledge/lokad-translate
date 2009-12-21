using System;
using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for a user repository.</summary>
	public interface IUserRepository
	{
		/// <summary>Creates a new user.</summary>
		/// <param name="user">The new user.</param>
		void Create(User user);
		
		/// <summary>Deletes a user.</summary>
		/// <param name="id">The ID of the user to delete.</param>
		void Delete(long id);
		
		/// <summary>Starts editing a user.</summary>
		/// <param name="id">The ID of the user to edit.</param>
		/// <returns>The user.</returns>
		User Edit(long id);
		
		/// <summary>Saves changes to a user.</summary>
		/// <param name="id">The ID of the user to save.</param>
		/// <param name="user">The updated user.</param>
		void Edit(long id, User user);
		
		/// <summary>Finds a user by username.</summary>
		/// <param name="username">The username to look for.</param>
		/// <returns>The user or <c>null</c>.</returns>
		User Get(string username);
		
		/// <summary>Lists all users.</summary>
		/// <returns>The users.</returns>
		IList<User> List();
	}
}
