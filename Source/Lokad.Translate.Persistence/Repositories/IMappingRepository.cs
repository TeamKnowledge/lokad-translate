#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Repositories
{
	/// <summary>Interface for a mapping repository.</summary>
	public interface IMappingRepository
	{
		/// <summary>Creates a new mapping.</summary>
		/// <param name="mapping">The new mapping.</param>
		void Create(Mapping mapping);

		/// <summary>Starts editing a mapping.</summary>
		/// <param name="id">The ID of the mapping to edit.</param>
		/// <returns>The mapping.</returns>
		Mapping Edit(long id);
		
		/// <summary>Saves changes to a mapping.</summary>
		/// <param name="id">The ID of the mapping.</param>
		/// <param name="mapping">The updated mapping.</param>
		/// <returns>The updated mapping.</returns>
		Mapping Edit(long id, Mapping mapping);
		
		/// <summary>Lists all mappings with a specified code.</summary>
		/// <param name="code">The code.</param>
		/// <returns>The mappings whose code matches <paramref name="code"/>.</returns>
		IList<Mapping> List(string code);
		
		/// <summary>Gets the mapping next to another whose ID is specified.</summary>
		/// <param name="id">The ID of the previous mapping.</param>
		/// <returns>The ID of the mapping next to <paramref name="id"/>.</returns>
		long Next(long id);
		
		/// <summary>Updates a mapping.</summary>
		/// <param name="mapping">The mapping.</param>
		void Update(Mapping mapping);

		/// <summary>Delete the mapping.</summary>
		/// <param name="id">The ID of the mapping.</param>
		/// <remarks>Delete all corresponding worklogs.</remarks>
		void Delete(long id);
	}
}
