#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
