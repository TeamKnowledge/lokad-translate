#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Configuration;
using System.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lokad.Translate.BusinessLogic;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using Microsoft.WindowsAzure.ServiceRuntime;
using NHibernate;

namespace Lokad.Translate
{
	public static class GlobalSetup
	{

		#region NHibernate

		// public because it's needed in the web app for ELMAH
		public static string ConnectionString
		{
			get 
			{
				return RoleEnvironment.IsAvailable ? 
					RoleEnvironment.GetConfigurationSettingValue("SqlConnectionString") : 
					ConfigurationManager.ConnectionStrings["SqlServices"].ConnectionString;
			}
		}

		#endregion

		#region IoC

		static IContainerProvider _containerProvider;

		static IContainer SetUp()
		{
			var builder = new ContainerBuilder();

			builder.Register(context =>
				{
					var model = AutoMap.AssemblyOf<DbVersion>()
						.Where(t => t.Namespace == "Lokad.Translate.Entities");

					return Fluently.Configure()
						.Database(MsSqlConfiguration.MsSql2008
							.ConnectionString(c => c.Is(ConnectionString)))
						.Mappings(m => m.AutoMappings.Add(model))
						.BuildSessionFactory();
				}).SingletonScoped();

			builder.Register(c =>
			{
				ISession session = c.Resolve<ISessionFactory>().OpenSession();
				session.FlushMode = FlushMode.Commit;
				return session;
			}).ContainerScoped();

			builder.RegisterModule(new RepositoriesModule());

			builder.Register<PageProcessor>().FactoryScoped();
			builder.Register<FeedProcessor>().FactoryScoped();

			return builder.Build();
		}

		/// <summary>Indicates whether the current application is an ASP.NET application.</summary>
		public static bool IsAspNetApplication {
			get
			{
				return HttpContext.Current != null;
			}
		}

		/// <summary>Gets the IoC container as initialized by the setup.</summary>
		/// <remarks>Automatically handles ASP.NET applications.</remarks>
		public static IContainer Container
		{
			get
			{
				if(null == _containerProvider)
				{
					_containerProvider = new ContainerProvider(SetUp());
				}

				if(IsAspNetApplication) return _containerProvider.RequestContainer;
				else return _containerProvider.ApplicationContainer;
			}
		}

		/// <summary>Disposes the current request container.</summary>
		public static void DisposeRequestContainer()
		{
			if(!IsAspNetApplication) throw new InvalidOperationException("The current application is not an ASP.NET application");

			if(_containerProvider != null) _containerProvider.DisposeRequestContainer();
		}

		#endregion
	}
}
