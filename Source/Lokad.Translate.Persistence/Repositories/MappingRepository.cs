using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Lokad.Translate.Repositories
{
	public class MappingRepository : BaseRepository
	{
		public MappingRepository()
		{
		}

		public MappingRepository(ISession session) : base(session)
		{
		}

		public IList<Mapping> List(string code)
		{
			return Session.CreateCriteria(typeof(Mapping))
					.Add(Restrictions.Eq("Code", code)).List<Mapping>()
					.OrderByDescending(m => Order(m)).ToList();
		}

		public static DateTime Order(Mapping m)
		{
			if(m.LastUpdated < m.Page.LastUpdated ||
				string.IsNullOrEmpty(m.DestinationUrl) ||
				string.IsNullOrEmpty(m.Version))
			{
				return m.LastUpdated.AddYears(10);
			}
			return m.LastUpdated;
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
