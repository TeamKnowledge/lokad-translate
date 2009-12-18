using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
