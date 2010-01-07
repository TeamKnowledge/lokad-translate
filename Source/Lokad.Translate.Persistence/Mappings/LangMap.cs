﻿#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
