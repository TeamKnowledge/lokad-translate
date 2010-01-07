#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;

namespace Lokad.Translate.Entities
{
	/// <summary>Feeds are used to collected page URLs.</summary>
	public class Feed
	{
		public virtual long Id { get; set; }

		public virtual DateTime Created { get; set; }

		public virtual string Name { get; set; }

		public virtual string Url { get; set; }
	}
}
