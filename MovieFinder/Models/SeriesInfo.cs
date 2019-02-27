using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieFinder.Models
{
    public class SeriesInfo
    {
        public string SeriesName { get; set; }

        public string Overview { get; set; }

        public string Runtime { get; set; }

        [JsonProperty("genre")]
        public List<string> Genres { get; set; }

        public string Network { get; set; }

        public double SiteRating { get; set; }

        public string Banner { get; set; }
    }
}