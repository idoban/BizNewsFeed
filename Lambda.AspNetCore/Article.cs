using System;

namespace Lambda.AspNetCore
{
	public class Article
	{
		public ArticleSource Source { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public string Url { get; set; }

		public string urlToImage { get; set; }
		public DateTime publishedAt { get; set; }

        public string category { get; set; }
	}
}