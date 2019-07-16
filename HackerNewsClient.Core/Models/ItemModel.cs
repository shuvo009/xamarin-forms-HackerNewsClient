using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HackerNewsClient.Core.Models
{
    public class ItemModel
    {
        [JsonProperty("by")]
        public string By { get; set; }

        [JsonProperty("descendants")]
        public string Descendants { get; set; }
        
        [JsonProperty("id")]
        public long Id { get; set; }

        //[JsonProperty("kids")]
        //public List<long> Kids { get; set; }

        //[JsonProperty("parts")]
        //public List<long> Parts { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }
        
        [JsonProperty("time")]
        public long Time { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
