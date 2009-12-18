using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class RestRegexMap : ClassMap<RestRegex>
	{
		public RestRegexMap()
		{
			Id(x => x.Id);
			Map(x => x.IsDiff);
			Map(x => x.IsEdit);
			Map(x => x.IsHistory);
			Map(x => x.MatchRegex).Not.Nullable().Length(255);
			Map(x => x.Name).Not.Nullable().Length(50);
			Map(x => x.ReplaceRegex).Not.Nullable().Length(255);
		}
	}
}
