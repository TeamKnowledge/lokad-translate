using System.Configuration;
using Lokad.Translate.Entities;
using Microsoft.WindowsAzure.ServiceRuntime;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Lokad.Translate
{
	public static class GlobalSetup
	{
		static string ConnectionString
		{
			get 
			{
				return RoleEnvironment.IsAvailable ? 
					RoleEnvironment.GetConfigurationSettingValue("SqlConnectionString") : 
					ConfigurationManager.ConnectionStrings["SqlServices"].ConnectionString;
			}
		}

		private static ISessionFactory _sessionFactory;
		private static ISession _session;

		public static ISessionFactory SessionFactory
		{
			get
			{
				// HACK: not thread safe singleton
				if(_sessionFactory == null)
				{
					_sessionFactory = CreateSessionFactory();
				}

				return _sessionFactory;
			}
		}

		public static ISession CurrentSession
		{
			get
			{
				// TODO: NHibernate session never closed.
				if(_session == null)
				{
					_session = SessionFactory.OpenSession();
					// at least changes will be sent, not when GC kicks in,
					// but at the end of the transaction
					_session.FlushMode = FlushMode.Commit;
				}

				return _session;
			}
		}

		static ISessionFactory CreateSessionFactory()
		{
			var model = AutoMap.AssemblyOf<DbVersion>()
				.Where(t => t.Namespace == "Lokad.Translate.Entities");

			return Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008
					.ConnectionString(c => c.Is(ConnectionString)))
				.Mappings(m => m.AutoMappings.Add(model))
				.BuildSessionFactory();
		}
	}
}
