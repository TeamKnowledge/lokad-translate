#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using Lokad.Translate.Entities;
using System.Collections.Generic;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for a page repository.</summary>
	public interface IPageRepository
	{
		/// <summary>Creates a new page.</summary>
		/// <param name="page">The new page.</param>
		void Create(Page page);

		/// <summary>Deletes a page.</summary>
		/// <param name="id">The ID of the page to delete.</param>
		void Delete(long id);

		/// <summary>Starts editing a page.</summary>
		/// <param name="id">The ID of the page to edit.</param>
		/// <returns>The page.</returns>
		Page Edit(long id);
		
		/// <summary>Saves changes to a page, except modified date.</summary>
		/// <param name="id">The ID of the page.</param>
		/// <param name="page">The updated page.</param>
		void Edit(long id, Page page);

		/// <summary>Saves changes to a page, include modified date.</summary>
		/// <param name="id">The ID of the page.</param>
		/// <param name="page">The updated page.</param>
		void EditFull(long id, Page page);
		
		/// <summary>Finds a page by URL.</summary>
		/// <param name="url">The URL to look for.</param>
		/// <returns>The page or <c>null</c>.</returns>
		Page Find(string url);
		
		/// <summary>Lists all pages.</summary>
		/// <returns>The pages.</returns>
		IList<Page> List();
	}
}
