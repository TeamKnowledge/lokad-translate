#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
