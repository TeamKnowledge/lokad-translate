using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace Lokad.Translate.Repositories
{
	public class RestRegexRepository : BaseRepository, IRestRegexRepository
	{
		public IList<RestRegex> List()
		{
			return Session.CreateCriteria(typeof(RestRegex)).List<RestRegex>()
				.OrderBy(u => u.Name).ToList();
		}

		public IList<RestRegex> ListEdit()
		{
			return Session.CreateCriteria(typeof(RestRegex))
				.Add(Restrictions.Eq("IsEdit", true))
				.List<RestRegex>()
				.OrderBy(u => u.Name).ToList();
		}

		public IList<RestRegex> ListHistory()
		{
			return Session.CreateCriteria(typeof(RestRegex))
				.Add(Restrictions.Eq("IsHistory", true))
				.List<RestRegex>()
				.OrderBy(u => u.Name).ToList();
		}

		public IList<RestRegex> ListDiff()
		{
			return Session.CreateCriteria(typeof(RestRegex))
				.Add(Restrictions.Eq("IsDiff", true))
				.List<RestRegex>()
				.OrderBy(u => u.Name).ToList();
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
