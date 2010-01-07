#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Collections.Generic;

namespace Lokad.Translate.Entities
{
	/// <summary>Resource web page, to be localized by translators.</summary>
	public class Page
	{
		public virtual long Id { get; private set; }

		public virtual DateTime Created { get; set; }

		public virtual string Url { get; set; }

		public virtual DateTime LastUpdated { get; set; }

		/// <summary>Indicates whether page updates should
		/// be carried on as mapping updates.</summary>
		/// <remarks>This property is used to exclude pages
		/// from the scope of the l10n process.</remarks>
		public virtual bool IsIgnored { get; set; }

		/// <summary>One mapping per target <see cref="Lang"/>.</summary>
		public virtual IList<Mapping> Mappings { get; set; }

		public Page()
		{
			Mappings = new List<Mapping>();
		}
	}
}
