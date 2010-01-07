#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class UpdateBatchRepository : BaseRepository, IUpdateBatchRepository
	{
		public IList<UpdateBatch> List()
		{
			return
				(from u in Session.Linq<UpdateBatch>()
				 orderby u.Created descending
				 select u).ToList();
		}

		public IList<UpdateBatch> Pending()
		{
			var updates =
				(from u in Session.Linq<Update>()
				 where u.UpdateBatch == null
				 select u).ToList();

			var batches = updates
				.GroupBy(u => u.User)
				.Select(u => new UpdateBatch
	             	{
	             		Created	= DateTime.UtcNow,
                        User = u.Key,
						WordCount = u.Sum(x => x.WordCount)
	             	})
				.ToList();

			return batches;
		}

		public void CreateBatch(long id)
		{
			var user = Session.Get<User>(id);

			var updates = Session.CreateCriteria(typeof(Update))
				.Add(Restrictions.IsNull("UpdateBatch"))
				.List<Update>()
				.Where(u => u.User.Id == user.Id).ToList();

			var batch = new UpdateBatch
	            	{
                        Created = DateTime.UtcNow,
						Updates = updates,
						User = user,
						WordCount = updates.Sum(u => u.WordCount)
	            	};

			using (var trans = Session.BeginTransaction())
			{
				Session.Save(batch);

				foreach(var update in updates)
				{
					update.UpdateBatch = batch;
					Session.Update(update);
				}

				trans.Commit();
			}
		}

		public UpdateBatch Get(long id)
		{
			return Session.Get<UpdateBatch>(id);
		}

		public UpdateBatch ToggleIsPaid(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var batch = Session.Get<UpdateBatch>(id);
				batch.IsPaid = !batch.IsPaid;

				Session.Update(batch);

				trans.Commit();

				return batch;
			}
		}
	}
}
