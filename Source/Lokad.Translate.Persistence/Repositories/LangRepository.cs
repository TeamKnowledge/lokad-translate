#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

using System.Collections.Generic;
using System.Linq;
using Lokad.Translate.Entities;
using NHibernate.Linq;

namespace Lokad.Translate.Repositories
{
	public class LangRepository : BaseRepository, ILangRepository
	{
		public IList<Lang> List()
		{
			return
				(from l in Session.Linq<Lang>()
				 select l).ToList();
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
