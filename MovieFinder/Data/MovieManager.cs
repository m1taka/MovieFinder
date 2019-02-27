using MovieFinder.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace MovieFinder.Data
{
    public class MovieManager
    {
        public static List<MovieInfo> SearchMovie(string name, string token)
        {
            string searchUrl = "https://api.thetvdb.com/search/series?name=";
            searchUrl += HttpUtility.UrlEncode(name);

            var client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + token);
            client.Headers.Add("Content-Type", "application/json");
            var result = client.DownloadString(searchUrl);
            var movieInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            return JsonConvert.DeserializeObject<List<MovieInfo>>(movieInfo["data"].ToString());
        }

        public static SeriesInfo GetSeriesInfo(int id, string token)
        {
            string searchUrl = "https://api.thetvdb.com/series/" + id;

            var client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + token);
            client.Headers.Add("Content-Type", "application/json");
            var result = client.DownloadString(searchUrl);
            var seriesInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            return JsonConvert.DeserializeObject<SeriesInfo>(seriesInfo["data"].ToString());
        }
    }
}