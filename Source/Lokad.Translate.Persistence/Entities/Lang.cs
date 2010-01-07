#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

namespace Lokad.Translate.Entities
{
	/// <summary>Target lang for localization process.</summary>
	public class Lang
	{
		public virtual long Id { get; private set; }

		/// <summary>Human-reabable code, shortcut for the target language.</summary>
		public virtual string Code { get; set; }
	}
}
