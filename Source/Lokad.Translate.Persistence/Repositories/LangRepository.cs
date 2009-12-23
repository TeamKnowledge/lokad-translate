using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using NHibernate;

namespace Lokad.Translate.Repositories
{
	public class LangRepository : BaseRepository, ILangRepository
	{
		public IList<Lang> List()
		{
			return Session.CreateCriteria(typeof(Lang)).List<Lang>();
		}

		public void Create(Lang lang)
		{
			using (var trans = Session.BeginTransaction())
			{
				Session.Save(lang);
				trans.Commit();
			}
		}

		public Lang Edit(long id)
		{
			return Session.Get<Lang>(id);
		}

		public void Edit(long id, Lang lang)
		{
			using (var trans = Session.BeginTransaction())
			{
				var dbLang = Session.Get<Lang>(id);

				dbLang.Code = lang.Code;

				Session.Update(dbLang);
				trans.Commit();
			}
		}

		public void Delete(long id)
		{
			using (var trans = Session.BeginTransaction())
			{
				var lang = Session.Get<Lang>(id);
				Session.Delete(lang);

				trans.Commit();
			}
		}
	}
}
