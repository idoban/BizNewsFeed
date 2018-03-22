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
            var newsFeed = new NewsFeed();

            string[] queryKeywords = { "בנק לאומי", "בנק הפועלים", "בנק דיסקונט", "בנק מזרחי", "בנק הבינלאומי", "בנק איגוד", "כלל ביטוח", "מגדל ביטוח", "הראל ביטוח", "הפניקס" };

            foreach (string keyword in queryKeywords) {
                var uriBuilder = BuildUri(keyword);
                var rawFeed = _client.GetStringAsync(uriBuilder.Uri).Result;
                var articlesFeed = JsonConvert.DeserializeObject<NewsFeed>(rawFeed);

                foreach (Article article in articlesFeed.Articles) {
                    if (SourceIsValid(article) && article.Description.Contains(keyword)) {
                        article.category = FindCategoryFor(keyword);
                        newsFeed.Articles.Add(article);
                        }
                    }
                }
            newsFeed.Status = "ok";
            newsFeed.TotalResults = newsFeed.Articles.Count;
            return newsFeed;
            }

        private string FindCategoryFor(string keyword)
        {
            //Super hardcoded categories
            string generalCategory = "כללי";
            string[] categories = {"ביטוח", "בנק"};

            foreach (string category in categories) {
                if (keyword.Contains(category)) return category;
            }
            return generalCategory;
        }

        private UriBuilder BuildUri(string queryKeyword)
        {
            var uriBuilder = new UriBuilder();
            uriBuilder.Host = "newsapi.org";
            uriBuilder.Path = "/v2/everything";
            uriBuilder.Query = string.Format("q={0}apiKey=008a35d17665443a9188d00cf704643d", queryKeyword);

            return uriBuilder;
        }

        private Boolean SourceIsValid(Article article){
            string[] defaultValidSourceNames = { "Globes.co.il", "Calcalist.co.il", "Themarker.com" };

            var sourceName = article.Source.Name;
            foreach (string sn in defaultValidSourceNames)
            {
                if (sourceName.Contains(sn)){
                    return true;
                }
            }
            return false;
        }
    }
}