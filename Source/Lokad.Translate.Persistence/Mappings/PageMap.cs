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