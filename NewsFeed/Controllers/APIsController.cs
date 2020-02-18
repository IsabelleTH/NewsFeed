using NewsFeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsFeed.Controllers
{
    public class APIsController : Controller
    {
        public ActionResult GetByCategory(string categoryName)
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var articles = client.GetArticles(categoryName);
            return View(articles);
        }

        public ActionResult Nyheter()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var articles = client.GetArticles("bitcoin");
            return View(articles);
        }

        public ActionResult Sports()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var sportsArticles = client.GetSportArticles();
            return View(sportsArticles);
        }

        public ActionResult Business()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var businessArticles = client.GetBusinessArticles();
            return View(businessArticles);
        }

        public ActionResult Entertainment()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var entertainmentArticles = client.GetEntertainmentArticles();
            return View(entertainmentArticles);
        }

        public ActionResult Science()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var scienceArticles = client.GetScienceArticles();
            return View(scienceArticles);
        }

        public ActionResult Technology()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var technologyArticles = client.GetTechnologyArticles();
            return View(technologyArticles);
        }

        public ActionResult General()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var generalArticles = client.GetGeneralArticles();
            return View(generalArticles);
        }


    }
}