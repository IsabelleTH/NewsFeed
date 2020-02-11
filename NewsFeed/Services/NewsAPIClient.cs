using NewsFeed.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace NewsFeed.Services
{
    public class NewsAPIClient
    {
        private readonly string _apiKey = "";

        public NewsAPIClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<Article> GetArticles(string query)
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/everything?q={query}&language=en&from={from.ToShortDateString()}&sortBy=publishedAt&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetSportArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=sports&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetBusinessArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetEntertainmentArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=entertainment&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetScienceArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=science&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetTechnologyArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=science&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }

        public List<Article> GetGeneralArticles()
        {
            var client = new WebClient();
            var from = DateTime.Now.AddMonths(-1);
            var content = client.DownloadString($"https://newsapi.org/v2/top-headlines?country=us&category=science&apiKey={_apiKey}");
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseModel>(content);

            return (response.Articles);
        }



    }
}