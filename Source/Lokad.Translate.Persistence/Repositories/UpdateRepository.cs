#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class UpdateRepository : BaseRepository, IUpdateRepository
	{
		public IList<Update> List()
		{
			return
				(from u in Session.Linq<Update>()
				 orderby u.Created descending
				 select u).ToList();
		}

		public IList<Update> List(long userId)
		{
			return
				(from u in Session.Linq<Update>()
				 where u.User.Id == userId
				 orderby u.Created descending
				 select u).ToList();
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
