using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Lokad.Translate.Repositories
{
	public class UpdateRepository : BaseRepository, IUpdateRepository
	{
		public IList<Update> List()
		{
			return Session.CreateCriteria(typeof(Update))
				.List<Update>().OrderByDescending(u => u.Created).ToList();
		}

		public IList<Update> List(long userId)
		{
			// HACK: performance issue here (retrieving all updates)
			return Session.CreateCriteria(typeof(Update)).List<Update>()
				.Where(u => u.User.Id == userId)
				.OrderByDescending(u => u.Created).ToList();
		}

		public void Create(Update update)
		{
			// HACK: should be using database-side value generation?
			update.Created = DateTime.UtcNow;

			using (var trans = Session.BeginTransaction())
			{
				Session.Save(update);
				trans.Commit();
			}
		}

		public Update Edit(long id)
		{
			return Session.Get<Update>(id);
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var update = Session.Get<Update>(id);

				if(update.UpdateBatch != null)
				{
					throw new InvalidOperationException(
						"Update cannot be deleted once part of a job.");
				}

				Session.Delete(update);
				trans.Commit();
			}
		}
	}
}
