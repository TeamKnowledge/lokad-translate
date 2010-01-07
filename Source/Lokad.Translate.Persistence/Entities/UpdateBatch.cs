#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Collections.Generic;

namespace Lokad.Translate.Entities
{
	/// <summary>The admin can gather all pending updates for a translator
	/// in a single batch. The purpose of the batch is to faciliate the 
	/// management of translator works.</summary>
	public class UpdateBatch
	{
		public virtual long Id { get; set; }

		public virtual DateTime Created { get; set; }

		public virtual User User { get; set; }

		public virtual int WordCount { get; set; }

		public virtual bool IsPaid { get; set; }

		public virtual IList<Update> Updates { get; set; }

		public UpdateBatch()
		{
			Updates = new List<Update>();
		}
	}
}
