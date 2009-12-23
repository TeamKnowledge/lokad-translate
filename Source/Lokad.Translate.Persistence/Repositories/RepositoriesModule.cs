using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;

namespace Lokad.Translate.Repositories
{
	/// <summary>
	/// Defines an Autofac module for repositories.
	/// </summary>
	public sealed class RepositoriesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c =>
			{
				return (IFeedRepository)new FeedRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IPageRepository)new PageRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IUserRepository)new UserRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (ILangRepository)new LangRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IMappingRepository)new MappingRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IUpdateRepository)new UpdateRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IRestRegexRepository)new RestRegexRepository();
			}).FactoryScoped();

			builder.Register(c =>
			{
				return (IUpdateBatchRepository)new UpdateBatchRepository();
			}).FactoryScoped();
		}
	}
}
