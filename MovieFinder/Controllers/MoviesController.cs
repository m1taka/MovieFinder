using MovieFinder.Data;
using MovieFinder.Models;
using System.Web.Mvc;

namespace MovieFinder.Controllers
{
    public class MoviesController : Controller
    {
        [HttpPost]
        public ActionResult Search(SearchBindingModel model)
        {
            var movieInfos = MovieManager.SearchMovie(model.SearchText, (string)this.HttpContext.Application["token"]);
            foreach (var movieInfo in movieInfos)
            {
                movieInfo.Banner = this.GetFullBanner(movieInfo.Banner);
            }

            return this.View(movieInfos);
        }

        public ActionResult SeriesInfo(int id)
        {
            var seriesInfo = MovieManager.GetSeriesInfo(id, (string)this.HttpContext.Application["token"]);
            seriesInfo.Banner = this.GetFullBanner(seriesInfo.Banner);
            return this.View(seriesInfo);
        }

        private string GetFullBanner(string bannerId)
        {
            return "http://thetvdb.com/banners/" + bannerId;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
                                                  
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}