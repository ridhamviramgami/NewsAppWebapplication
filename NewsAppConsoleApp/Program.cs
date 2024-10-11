using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using System.Text.Json;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //enter topic
            Console.Write("Enter the topic: ");
            string topic = Console.ReadLine();

            // init with your API key
            var newsApiClient = new NewsApiClient("222a6988d2c44e05ab11aaaaf619e4e0");

            //call news api with these parameters
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = topic,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.Today.AddDays(-1)
            });

            string json = JsonSerializer.Serialize(articlesResponse);

            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);

                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(article.Title);
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description);
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine(article.PublishedAt);
                }
            }
            Console.ReadLine();
        }
    }
}