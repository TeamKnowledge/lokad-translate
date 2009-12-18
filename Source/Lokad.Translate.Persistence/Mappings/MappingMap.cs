using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class MappingMap : ClassMap<Mapping>
	{
		public MappingMap()
		{
			Id(x => x.Id);
			References(x => x.Page).Not.Nullable();
			Map(x => x.Created);
			Map(x => x.Code);
			Map(x => x.DestinationUrl).Length(255);
			Map(x => x.LastUpdated);
			Map(x => x.Version).Length(50);
			HasMany(x => x.Updates).Cascade.AllDeleteOrphan().Inverse();
		}
	}
}
