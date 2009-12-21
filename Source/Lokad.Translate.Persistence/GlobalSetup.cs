using System.Configuration;
using Autofac;
using Autofac.Builder;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using Microsoft.WindowsAzure.ServiceRuntime;
using NHibernate;
using Lokad.Translate.BusinessLogic;

namespace Lokad.Translate
{
	public static class GlobalSetup
	{

		#region NHibernate

		static string ConnectionString
		{
			get 
			{
				return RoleEnvironment.IsAvailable ? 
					RoleEnvironment.GetConfigurationSettingValue("SqlConnectionString") : 
					ConfigurationManager.ConnectionStrings["SqlServices"].ConnectionString;
			}
		}

		private static object _syncLock = new object();
		private static ISessionFactory _sessionFactory;
		private static ISession _session;

		public static ISessionFactory SessionFactory
		{
			get
			{
				if(_sessionFactory == null)
				{
					lock(_syncLock)
					{
						if(_sessionFactory == null)
						{
							_sessionFactory = CreateSessionFactory();
						}
					}
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

		#endregion

		#region IoC

		static IContainer _container;

		static IContainer SetUp()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new RepositoriesModule());

			builder.Register<PageProcessor>();
			builder.Register<FeedProcessor>();

			return builder.Build();
		}

		/// <summary>Gets the IoC container as initialized by the setup.</summary>
		public static IContainer Container
		{
			get
			{
				if(null == _container)
				{
					_container = SetUp();
				}

				return _container;
			}
		}

		#endregion
	}
}
