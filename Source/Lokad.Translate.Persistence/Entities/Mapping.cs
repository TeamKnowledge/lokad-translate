using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lokad.Translate.Entities
{
	/// <summary>Mapping from the original webpage to the translated one.</summary>
	public class Mapping
	{
		public virtual long Id { get; private set; }

		public virtual Page Page { get; set; }

		public virtual DateTime Created { get; set; }
		
		/// <summary>Language code.</summary>
		public virtual string Code { get; set; }

		public virtual string DestinationUrl { get; set; }

		public virtual DateTime LastUpdated { get; set; }

		/// <summary>Version identifier indicated with version of the original
		/// page is currently localized.</summary>
		public virtual string Version { get; set; }

		/// <summary>Updates that have been applied to the localized version
		/// by the translators.</summary>
		public virtual IList<Update> Updates { get; set; }

		public Mapping()
		{
			Updates = new List<Update>();
		}
	}
}
