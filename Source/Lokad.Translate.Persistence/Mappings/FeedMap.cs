using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class FeedMap : ClassMap<Feed>
	{
		public FeedMap()
		{
			Id(x => x.Id);
			Map(x => x.Created);
			Map(x => x.Name).Length(50);
			Map(x => x.Url).Length(255);
		}
	}
}
