using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using Lokad.Translate.Entities;
using Lokad.Translate.Repositories;
using NHibernate;

namespace Lokad.Translate.BusinessLogic
{
	/// <summary>Encapsulates the logic concerning processing
	/// feeds and updating pages.</summary>
	public class FeedProcessor
	{
		class FeedItem
		{
			public string Link { get; set; }
			public DateTime PubDate { get; set; }
		}

		readonly IFeedRepository Feeds;
		readonly IPageRepository Pages;

		public FeedProcessor(
			IFeedRepository feeds, 
			IPageRepository pages)
		{
			Feeds = feeds;
			Pages = pages;
		}

		/// <summary>Retrieves all the udaptes and
		/// inserts the new pages.</summary>
		/// <returns>Number of updated pages.</returns>
		public int ProcessAll()
		{
			var count = 0;
			foreach(var feed in Feeds.List())
			{
				count += ProcessFeed(feed.Id);
			}

			return count;
		}

		/// <summary>Retrieves all the udaptes and
		/// inserts the new pages.</summary>
		/// <returns>Number of updated pages.</returns>
		public int ProcessFeed(long feedId)
		{
			var feed = Feeds.Edit(feedId);

			var doc = new XPathDocument(feed.Url);

			// HACK: parsing should be made more fault tolerant
			
			// TODO: using 2 iterators is NOT the way to go.

			var nav = doc.CreateNavigator();
			var iter1 = nav.Select("/rss/channel/item/link");
			var iter2 = nav.Select("/rss/channel/item/pubDate");

			var feedItems = new List<FeedItem>();
			while (iter1.MoveNext())
			{
				iter2.MoveNext();

				feedItems.Add(new FeedItem
					{
						Link = iter1.Current.Value,
						PubDate = DateTime.Parse(iter2.Current.Value)
					});
			};

			foreach(var item in feedItems)
			{
				var page = Pages.Find(item.Link);

				if (null == page)
				{
					var now = DateTime.UtcNow;
					page = new Page
					       	{
					       		Created = now,
					       		LastUpdated = item.PubDate,
					       		Url = item.Link
					       	};

					Pages.Create(page);
				}
				else
				{
					page.LastUpdated = item.PubDate;
					Pages.Save(page);
				}
			}

			return feedItems.Count();
		}
	}
}
