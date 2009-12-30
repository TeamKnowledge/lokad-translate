using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class RestRegexRepository : BaseRepository, IRestRegexRepository
	{
		public IList<RestRegex> List()
		{
			return
				(from r in Session.Linq<RestRegex>()
				 orderby r.Name
				 select r).ToList();
		}

		public IList<RestRegex> ListEdit()
		{
			return
				(from r in Session.Linq<RestRegex>()
				 where r.IsEdit
				 orderby r.Name
				 select r).ToList();
		}

		public IList<RestRegex> ListHistory()
		{
			return
				(from r in Session.Linq<RestRegex>()
				 where r.IsHistory
				 orderby r.Name
				 select r).ToList();
		}

		public IList<RestRegex> ListDiff()
		{
			return
				(from r in Session.Linq<RestRegex>()
				 where r.IsDiff
				 orderby r.Name
				 select r).ToList();
		}

		public void Create(RestRegex regex)
		{
			using (var trans = Session.BeginTransaction())
			{
				Session.Save(regex);
				trans.Commit();
			}
		}

		public RestRegex Edit(long id)
		{
			return Session.Get<RestRegex>(id);
		}

		public void Edit(long id, RestRegex regex)
		{
			using (var trans = Session.BeginTransaction())
			{
				var dbRegex = Session.Get<RestRegex>(id);

				dbRegex.IsDiff = regex.IsDiff;
				dbRegex.IsEdit = regex.IsEdit;
				dbRegex.IsHistory = regex.IsHistory;
				dbRegex.MatchRegex = regex.MatchRegex;
				dbRegex.Name = regex.Name;
				dbRegex.ReplaceRegex = regex.ReplaceRegex;

				Session.Update(dbRegex);
				trans.Commit();
			}
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var regex = Session.Get<RestRegex>(id);
				Session.Delete(regex);
				trans.Commit();
			}
		}
	}
}
