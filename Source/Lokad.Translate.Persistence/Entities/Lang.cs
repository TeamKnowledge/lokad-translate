using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
