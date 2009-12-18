using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Lokad.Translate.Repositories
{
	public class BaseRepository
	{
		protected readonly ISession Session;

		public BaseRepository() : this(GlobalSetup.CurrentSession)
		{
		}

		public BaseRepository(ISession session)
		{
			Session = session;
		}
	}
}
