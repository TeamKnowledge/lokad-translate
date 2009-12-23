using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NHibernate;

namespace Lokad.Translate.Repositories
{
	public class BaseRepository
	{
		protected readonly ISession Session;

		public BaseRepository() : this(GlobalSetup.Container.Resolve<ISession>())
		{
		}

		public BaseRepository(ISession session)
		{
			Session = session;
		}
	}
}
