using NewsFeed.Services;
using System.Web.Mvc;

namespace NewsFeed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StartUp()
        {
            NewsAPIClient client = new NewsAPIClient("28d99b9a350f48d09c93459a32d4fa36");
            var articles = client.GetArticles("bitcoin");
            return View(articles);
        }
    }
}