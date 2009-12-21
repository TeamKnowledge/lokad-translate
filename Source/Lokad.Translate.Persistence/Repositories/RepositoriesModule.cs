using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			});

			builder.Register(c =>
			{
				return (IPageRepository)new PageRepository();
			});

			builder.Register(c =>
			{
				return (IUserRepository)new UserRepository();
			});

			builder.Register(c =>
			{
				return (ILangRepository)new LangRepository();
			});

			builder.Register(c =>
			{
				return (IMappingRepository)new MappingRepository();
			});

			builder.Register(c =>
			{
				return (IUpdateRepository)new UpdateRepository();
			});

			builder.Register(c =>
			{
				return (IRestRegexRepository)new RestRegexRepository();
			});

			builder.Register(c =>
			{
				return (IUpdateBatchRepository)new UpdateBatchRepository();
			});
		}
	}
}
