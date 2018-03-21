using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda.AspNetCore
{
	
	public class NewsFeedFunction
	{			
		public NewsFeed Handler()
		{
			//Console.WriteLine($"Processing request data for request {request.RequestContext.RequestId}.");
			//Console.WriteLine($"Body size = {request.Body.Length}.");
			//var headerNames = string.Join(", ", request.Headers.Keys);
			//Console.WriteLine($"Specified headers = {headerNames}.");

			return new NewsApiOrgProvider().GetNewsFeed();			 
		}
	}
}