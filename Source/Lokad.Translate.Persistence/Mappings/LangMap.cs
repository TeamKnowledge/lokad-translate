using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class LangMap : ClassMap<Lang>
	{
		public LangMap()
		{
			Id(x => x.Id);
			Map(x => x.Code).Length(10).Not.Nullable();
		}
	}
}
