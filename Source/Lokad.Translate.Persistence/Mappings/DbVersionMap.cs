using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class DbVersionMap : ClassMap<DbVersion>
	{
		public DbVersionMap()
		{
			Map(x => x.Id);
			Map(x => x.Created);
		}
	}
}
