#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Lokad.Translate.Repositories
{
	public class MappingRepository : BaseRepository, IMappingRepository
	{
		public IList<Mapping> List(string code)
		{
			return Session.CreateCriteria(typeof(Mapping)).SetFetchMode("Page", FetchMode.Eager)
					.Add(Restrictions.Eq("Code", code)).List<Mapping>()
					.OrderBy(ProcessingPriorityOrder).ToList();
		}

        /// <summary>
        /// Order by priority of condition
        /// </summary>
		public static int ProcessingPriorityOrder(Mapping m)
		{
            if (string.IsNullOrEmpty(m.DestinationUrl)) return 0;
            if (string.IsNullOrEmpty(m.Version)) return 1;
            if (m.Page.LastUpdated > m.LastUpdated) return 2;
            return 3;
		}

		public void Create(Mapping mapping)
		{
			mapping.Created = DateTime.UtcNow;
			mapping.LastUpdated = new DateTime(2001,1,1);

			using (var trans = Session.BeginTransaction())
			{
				Session.Save(mapping);
				trans.Commit();
			}
		}

		public Mapping Edit(long id)
		{
			return Session.Get<Mapping>(id);
		}

		public Mapping Edit(long id, Mapping mapping)
		{
			using (var trans = Session.BeginTransaction())
			{
				var dbMapping = Session.Get<Mapping>(id);
				dbMapping.DestinationUrl = mapping.DestinationUrl;

				Session.Update(dbMapping);
				trans.Commit();

				return dbMapping;
			}
		}

		public void Update(Mapping mapping)
		{
			using (var trans = Session.BeginTransaction())
			{
				Session.Update(mapping);
				trans.Commit();
			}
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				Session
					.CreateSQLQuery("Delete Mapping WHERE Id=?")
					.SetParameter(0, id)
					.ExecuteUpdate();

				trans.Commit();
			}
		}

		/// <summary>Utility to quickly navigate to the next mapping.</summary>
		public long Next(long id)
		{
			var mapping = Session.Get<Mapping>(id);

			var array = List(mapping.Code).ToArray();

			for(int i = 0; i < array.Length; i++)
			{
				if(array[i].Id == id)
				{
					return array[(i + 1)%array.Length].Id;
				}
			}

			return array[0].Id;
		}
	}
}
