using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class UpdateBatchMap : ClassMap<UpdateBatch>
	{
		public UpdateBatchMap()
		{
			Id(x => x.Id);
			Map(x => x.Created);
			Map(x => x.WordCount);
			Map(x => x.IsPaid);
			References(x => x.User);
			HasMany(x => x.Updates).Cascade.AllDeleteOrphan();
		}
	}
}
