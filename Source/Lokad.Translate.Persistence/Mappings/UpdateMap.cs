using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class UpdateMap : ClassMap<Update>
	{
		public UpdateMap()
		{
			Id(x => x.Id);
			Map(x => x.Created);
			Map(x => x.Version).Length(50);
			Map(x => x.WordCount);
			References(x => x.User);
			References(x => x.Mapping).Not.Nullable();
			References(x => x.UpdateBatch);
		}
	}
}
