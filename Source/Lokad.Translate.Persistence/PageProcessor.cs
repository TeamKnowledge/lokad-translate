using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using NHibernate;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Encapsulates the logic concerning page updates
	/// and mapping updates.</summary>
	public class PageProcessor
	{
		private readonly IPageRepository Pages;
		private readonly ILangRepository Langs;
		private readonly IMappingRepository Mappings;

		public PageProcessor(
			IPageRepository pages,
			ILangRepository langs, 
			IMappingRepository mappings)
		{
			Pages = pages;
			Langs = langs;
			Mappings = mappings;
		}

		/// <summary>Create missing mappings.</summary>
		/// <return>The number of inserted mappings.</return>
		public void ProcessPage(Page page)
		{
			var langs = Langs.List().ToArray();

			var maps = page.Mappings;
			var now = DateTime.UtcNow;

			foreach (var lang in langs.Where(x => !maps.Any(y => y.Code == x.Code)))
			{
				var mapping = new Mapping
	              	{
	              		Code = lang.Code,
	              		Created = now,
	              		Page = page
	              	};
				page.Mappings.Add(mapping);

				Mappings.Create(mapping);
			}
		}

		/// <summary>Create all missing mappings.</summary>
		/// <returns>The number of new mappings.</returns>
		public int ProcessAll()
		{
			var count = 0;

			// TODO: performance is really poor, to be redesigned
			var langs = Langs.List().ToArray();

			var now = DateTime.UtcNow;

			foreach(var page in Pages.List())
			{
				var mapLangs = new List<string>();

				// Creating the missing mappings
				foreach(var lang in langs.Where(u => !mapLangs.Contains(u.Code)))
				{
					var mapping = new Mapping
					{
						Code = lang.Code,
						Created = now,
						Page = page
					};
					page.Mappings.Add(mapping);
					Mappings.Create(mapping);

					count++;
				}
			}

			return count;
		}
	}
}
