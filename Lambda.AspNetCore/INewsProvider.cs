namespace Lambda.AspNetCore
{
	public interface INewsProvider
	{
		NewsFeed GetNewsFeed();
	}
}