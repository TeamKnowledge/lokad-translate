using System;
using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for a feed repository.</summary>
	public interface IFeedRepository
	{
		/// <summary>Creates a new feed.</summary>
		/// <param name="feed">The new feed.</param>
		void Create(Feed feed);

		/// <summary>Deletes a feed.</summary>
		/// <param name="id">The ID of the feed to delete.</param>
		void Delete(long id);

		/// <summary>Starts editing a feed.</summary>
		/// <param name="id">The ID of the feed to edit.</param>
		/// <returns>The feed.</returns>
		Feed Edit(long id);

		/// <summary>Saves changes to a feed.</summary>
		/// <param name="id">The ID of the feed.</param>
		/// <param name="feed">The updated feed.</param>
		void Edit(long id, Feed feed);

		/// <summary>Lists all feeds.</summary>
		/// <returns>The feeds.</returns>
		IList<Feed> List();
	}
}
