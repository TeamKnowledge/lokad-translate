#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
