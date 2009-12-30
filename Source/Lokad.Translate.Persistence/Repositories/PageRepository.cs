using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class PageRepository : BaseRepository, IPageRepository
	{
		public IList<Page> List()
		{
			return
				(from p in Session.Linq<Page>()
				 orderby p.LastUpdated
				 select p).ToList();
		}

		public void Create(Page page)
		{
			// HACK: should be using database-side value generation?
			page.Created = DateTime.UtcNow;
			page.LastUpdated = page.Created;

			using (var trans = Session.BeginTransaction())
			{
				Session.Save(page);
				trans.Commit();
			}
		}

		public Page Edit(long id)
		{
			return Session.Get<Page>(id);
		}

		public void Edit(long id, Page page)
		{
			using (var trans = Session.BeginTransaction())
			{
				var dbPage = Session.Get<Page>(id);

				// don't change 'LastUpdated' (on purpose)
				dbPage.IsIgnored = page.IsIgnored;
				dbPage.Url = page.Url;

				Session.Update(dbPage);
				trans.Commit();
			}
		}

		public void EditFull(long id, Page page)
		{
			using(var trans = Session.BeginTransaction())
			{
				var dbPage = Session.Get<Page>(id);

				dbPage.LastUpdated = page.LastUpdated;
				dbPage.IsIgnored = page.IsIgnored;
				dbPage.Url = page.Url;

				Session.Update(dbPage);
				trans.Commit();
			}
		}

		public Page Find(string url)
		{
			return
				(from p in Session.Linq<Page>()
				 where p.Url == url
				 select p).FirstOrDefault();
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var page = Session.Get<Page>(id);

				foreach (var mapping in page.Mappings)
				{
					if(mapping.Updates.Any())
					{
						trans.Rollback();

						throw new InvalidOperationException(
							"Cannot delete a page once translation works have been associated.");
					}
				}

				Session
					.CreateSQLQuery("Delete Page WHERE Id=?")
					.SetParameter(0, id)
					.ExecuteUpdate();

				//Session.Delete(page);
				trans.Commit();
			}
		}
	}
}
