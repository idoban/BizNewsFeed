using System.Collections.Generic;

namespace Lambda.AspNetCore
{
	public class NewsFeed
	{
		public string Status { get; set; }
		public int TotalResults { get; set; }
		public List<Article> Articles { get; set; }
	}
}