#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
