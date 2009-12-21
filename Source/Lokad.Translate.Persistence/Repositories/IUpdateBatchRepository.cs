using System;
using Lokad.Translate.Entities;
using System.Collections.Generic;

namespace Lokad.Translate.Repositories
{
	/// <summary>
	/// Interface for an update batch repository.
	/// </summary>
	public interface IUpdateBatchRepository
	{
		/// <summary>Creates a new batch.</summary>
		/// <param name="id">The ID of the batch.</param>
		void CreateBatch(long id);
		
		/// <summary>Gets a batch by ID.</summary>
		/// <param name="id">The ID of the batch.</param>
		/// <returns>The batch.</returns>
		UpdateBatch Get(long id);
		
		/// <summary>Lists all batches.</summary>
		/// <returns>The batches.</returns>
		IList<UpdateBatch> List();

		/// <summary>Lists all pending batches.</summary>
		/// <returns>The pending batches.</returns>
		IList<UpdateBatch> Pending();
		
		/// <summary>Toggles the 'IsPaid' property of a batch.</summary>
		/// <param name="id">The ID of the batch.</param>
		/// <returns>The updated batch.</returns>
		UpdateBatch ToggleIsPaid(long id);
	}
}
