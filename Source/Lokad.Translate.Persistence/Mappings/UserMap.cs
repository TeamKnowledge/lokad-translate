using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Lokad.Translate.Entities;

namespace Lokad.Translate.Mappings
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Id(x => x.Id);
			Map(x => x.OpenId).Length(255);
			Map(x => x.Created);
			Map(x => x.DisplayName).Length(50);
			Map(x => x.IsManager);
			Map(x => x.Code).Length(10);
		}
	}
}
