#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Linq;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Encapsulates the logic concerning page updates
	/// and mapping updates.</summary>
	public class PageProcessor
	{
		private readonly IPageRepository Pages;
		private readonly ILangRepository Langs;
		private readonly IMappingRepository Mappings;

		public PageProcessor(IPageRepository pages, ILangRepository langs, IMappingRepository mappings)
		{
			Pages = pages;
			Langs = langs;
			Mappings = mappings;
		}

		/// <summary>Create missing mappings for a page.</summary>
		/// <return>The number of inserted mappings.</return>
		public int ProcessPage(Page page)
		{
			// TODO: performance is really poor, to be redesigned (see also below)
			var langs = Langs.List().ToArray();

			return ProcessPage(page, langs);
		}

		/// <summary>Create missing mappings for a page.</summary>
		/// <return>The number of inserted mappings.</return>
		public int ProcessPage(Page page, Lang[] langs)
		{
            // don't process ignored pages
            if (page.IsIgnored) return 0;

			var maps = page.Mappings;
			var now = DateTime.UtcNow;

			var count = 0;

			// Creating the missing mappings
			foreach(var lang in langs.Where(x => !maps.Any(y => y.Code == x.Code)))
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

			return count;
		}

		/// <summary>Create all missing mappings.</summary>
		/// <returns>The number of new mappings.</returns>
		public int ProcessAll()
		{
			var count = 0;

			// TODO: performance is really poor, to be redesigned (see also above)
			var langs = Langs.List().ToArray();

			foreach(var page in Pages.List())
			{
				count += ProcessPage(page, langs);
			}

			return count;
		}
	}
}
