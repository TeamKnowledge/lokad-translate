#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

namespace Lokad.Translate.Entities
{
	/// <summary>Store the Regex patterns used to interact
	/// with a 3rd party REST API exposed by the targeted
	/// web app (ex: ScrewTurn).</summary>
	public class RestRegex
	{
		public virtual long Id { get; set; }

		/// <summary>Indicates whether the regex pattern is used to get
		/// the REST url displaying the history of the targeted page.</summary>
		public virtual bool IsHistory { get; set; }

		/// <summary>Indicates whether the regex pattern is used to get
		/// the REST url displaying the DIFF between the last translated
		/// version and the current version of the targeted page.</summary>
		public virtual bool IsDiff { get; set; }

		/// <summary>Indicates whether the regex pattern is used to navigate
		/// toward the edition mode for the targeted page.</summary>
		public virtual bool IsEdit { get; set; }

		/// <summary>Indicates whether the regex pattern is used to navigate
		/// toward the 'view code' mode for the targeted page.</summary>
		public virtual bool IsCode { get; set; }

		/// <summary>Name associated to the regex (for user readability only,
		/// it has no functional purpose).</summary>
		public virtual string Name { get; set; }

		public virtual string MatchRegex { get; set; }

		public virtual string ReplaceRegex { get; set; }
	}
}
