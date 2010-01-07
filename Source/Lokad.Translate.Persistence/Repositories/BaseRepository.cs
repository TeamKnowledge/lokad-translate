#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
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
