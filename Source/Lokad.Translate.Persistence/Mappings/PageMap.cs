#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class PageMap : ClassMap<Page>
	{
		public PageMap()
		{
			Id(x => x.Id);
			Map(x => x.Created);
			Map(x => x.IsIgnored);
			Map(x => x.LastUpdated);
			Map(x => x.Url).Length(255);
			HasMany(x => x.Mappings).Cascade.All().Inverse();
		}
	}
}