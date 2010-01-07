#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;

namespace Lokad.Translate.Entities
{
	/// <summary>Helper for DB schema versionning.</summary>
	public class DbVersion
	{
		public virtual int Id { get; set; }

		public virtual DateTime Created { get; set; }
	}
}
