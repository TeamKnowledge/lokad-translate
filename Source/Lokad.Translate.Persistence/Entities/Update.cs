using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lokad.Translate.Entities
{
	/// <summary>Record a elementary piece of word performed by
	/// a translator.</summary>
	public class Update
	{
		public virtual Mapping Mapping { get; set; }

		public virtual long Id { get; private set; }

		public virtual DateTime Created { get; set; }

		/// <summary>Word count is the basic work unit for translation
		/// works.</summary>
		public virtual int WordCount { get; set; }

		/// <summary>Version identifier indicating which state of the
		/// original page was actually translated.</summary>
		public virtual string Version { get; set; }

		/// <summary>Translator that have performed the work.</summary>
		public virtual User User { get; set; }

		public virtual UpdateBatch UpdateBatch { get; set; }
	}
}
