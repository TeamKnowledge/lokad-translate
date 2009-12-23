using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Lokad.Translate.Repositories
{
	public class PageRepository : BaseRepository, IPageRepository
	{
		public IList<Page> List()
		{
			return Session.CreateCriteria(typeof(Page)).List<Page>()
				.OrderByDescending(p => p.LastUpdated).ToList();
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

		public Page Find(string url)
		{
			var results = Session.CreateCriteria(typeof(Page))
					.Add(Restrictions.Eq("Url", url)).List<Page>();

			return results.Count > 0 ? results[0] : null;

		}

		public void Save(Page page)
		{
			using (var trans = Session.BeginTransaction())
			{
				Session.Save(page);
				trans.Commit();
			}
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
