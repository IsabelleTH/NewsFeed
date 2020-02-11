using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewsFeed.Models
{
    public class APIResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}