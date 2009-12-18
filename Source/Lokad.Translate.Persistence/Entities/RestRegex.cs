using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lokad.Translate.Entities
{
	/// <summary>Store the Regex patterns used to interact
	/// with a 3rd party REST API exposed by the targeted
	/// web app (ex: ScrewTurn).</summary>
	public class RestRegex
	{
		public virtual long Id { get; set; }

		public virtual bool IsHistory { get; set; }

		public virtual bool IsDiff { get; set; }

		public virtual bool IsEdit { get; set; }

		public virtual string Name { get; set; }

		public virtual string MatchRegex { get; set; }

		public virtual string ReplaceRegex { get; set; }
	}
}
