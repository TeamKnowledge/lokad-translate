using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lokad.Translate.Entities
{
	/// <summary>Helper for DB schema versionning.</summary>
	public class DbVersion
	{
		public virtual int Id { get; set; }

		public virtual DateTime Created { get; set; }
	}
}
