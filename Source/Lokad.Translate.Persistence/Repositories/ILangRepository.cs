using System;
using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for a language repository.</summary>
	public interface ILangRepository
	{
		/// <summary>Creates a new language.</summary>
		/// <param name="lang">The new language.</param>
		void Create(Lang lang);
		
		/// <summary>Deletes a language.</summary>
		/// <param name="id">the ID of the language to delete.</param>
		void Delete(long id);

		/// <summary>Starts editing a language.</summary>
		/// <param name="id">The ID of the language to edit.</param>
		/// <returns>The language.</returns>
		Lang Edit(long id);
		
		/// <summary>Saves changes to a language.</summary>
		/// <param name="id">The ID of the language.</param>
		/// <param name="lang">The updated language.</param>
		void Edit(long id, Lang lang);
		
		/// <summary>Lists all languages.</summary>
		/// <returns>The languages.</returns>
		IList<Lang> List();
	}
}
