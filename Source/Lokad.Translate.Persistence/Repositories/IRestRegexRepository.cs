#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using Lokad.Translate.Entities;
using System.Collections.Generic;

namespace Lokad.Translate.Repositories
{
	/// <summary>
	/// Interface for a REST regex repository.
	/// </summary>
	public interface IRestRegexRepository
	{
		/// <summary>Creates a new REST regex.</summary>
		/// <param name="regex">The new regex.</param>
		void Create(RestRegex regex);

		/// <summary>Deletes a REST regex.</summary>
		/// <param name="id">The ID of the REST regex to delete.</param>
		void Delete(long id);

		/// <summary>Starts editing a REST regex.</summary>
		/// <param name="id">The ID of the REST regex to edit.</param>
		/// <returns>The REST regex.</returns>
		RestRegex Edit(long id);
		
		/// <summary>Saves changes to a REST regex.</summary>
		/// <param name="id">The ID of the REST regex.</param>
		/// <param name="regex">The updated REST regex.</param>
		void Edit(long id, RestRegex regex);
		
		/// <summary>Lists all REST regexes.</summary>
		/// <returns>The REST regexes.</returns>
		IList<RestRegex> List();
		
		/// <summary>Lists all REST regexes of type 'diff'.</summary>
		/// <returns>The REST regexes of tye 'diff'.</returns>
		IList<RestRegex> ListDiff();

		/// <summary>Lists all REST regexes of type 'edit'.</summary>
		/// <returns>The REST regexes of tye 'edit'.</returns>
		IList<RestRegex> ListEdit();

		/// <summary>Lists all REST regexes of type 'history'.</summary>
		/// <returns>The REST regexes of tye 'history'.</returns>
		IList<RestRegex> ListHistory();
	}
}
