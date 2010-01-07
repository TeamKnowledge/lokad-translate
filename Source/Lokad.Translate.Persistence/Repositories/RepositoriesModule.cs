#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion

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
