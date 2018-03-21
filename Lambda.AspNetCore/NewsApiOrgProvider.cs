using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Lambda.AspNetCore
{
	public class NewsApiOrgProvider : INewsProvider
	{
		
		public static readonly HttpClient _client = new HttpClient();
		
		public NewsFeed GetNewsFeed()
		{
			var uriBuilder = new UriBuilder();

			uriBuilder.Host = "newsapi.org";
			uriBuilder.Path = "/v2/top-headlines";
			uriBuilder.Query = "country=il&category=business&apiKey=008a35d17665443a9188d00cf704643d";

			var rawFeed = _client.GetStringAsync(uriBuilder.Uri).Result;

			var newsFeed = JsonConvert.DeserializeObject<NewsFeed>(rawFeed);

			return newsFeed;
		}
	}
}