#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using Lokad.Translate.Entities;
using System.Collections.Generic;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for an update repository.</summary>
	public interface IUpdateRepository
	{
		/// <summary>Creates a new update.</summary>
		/// <param name="update">The new update.</param>
		void Create(Update update);
		
		/// <summary>Deletes an update.</summary>
		/// <param name="id">The ID of the update to delete.</param>
		void Delete(long id);
		
		/// <summary>Starts editing an update.</summary>
		/// <param name="id">The ID of the update.</param>
		/// <returns>The update.</returns>
		Update Edit(long id);
		
		/// <summary>Lists all udpates.</summary>
		/// <returns>The updates.</returns>
		IList<Update> List();
		
		/// <summary>Lists all updates of a user.</summary>
		/// <param name="userId">The ID of the user.</param>
		/// <returns>The updates of the user.</returns>
		IList<Update> List(long userId);

		/// <summary>Lists all udpates, not part of an update batch.</summary>
		/// <returns>The updates.</returns>
		IList<Update> ListNotBatched();

		/// <summary>Lists all updates of a user, not part of an update batch.</summary>
		/// <param name="userId">The ID of the user.</param>
		/// <returns>The updates of the user.</returns>
		IList<Update> ListNotBatched(long userId);
	}
}
