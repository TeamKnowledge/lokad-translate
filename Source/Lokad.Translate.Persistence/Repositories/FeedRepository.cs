using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class FeedRepository : BaseRepository, IFeedRepository
	{
		public IList<Feed> List()
		{
			return
				(from f in Session.Linq<Feed>()
				 select f).ToList();
		}

		public void Create(Feed feed)
		{
			// HACK: should be using database-side value generation?
			feed.Created = DateTime.UtcNow;

			using (var trans = Session.BeginTransaction())
			{
				Session.Save(feed);
				trans.Commit();
			}
		}

		public Feed Edit(long id)
		{
			return Session.Get<Feed>(id);
		}

		public void Edit(long id, Feed feed)
		{
			using (var trans = Session.BeginTransaction())
			{
				var dbFeed = Session.Get<Feed>(id);

				dbFeed.Name = feed.Name;
				dbFeed.Url = feed.Url;

				Session.Update(dbFeed);
				trans.Commit();
			}
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var feed = Session.Get<Feed>(id);
				Session.Delete(feed);
				trans.Commit();
			}
		}
	}
}
