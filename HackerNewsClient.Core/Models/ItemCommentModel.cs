using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsClient.Core.Models
{
    public class ItemCommentModel
    {
        [JsonProperty("by")]
        public string By { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kids")]
        public long[] Kids { get; set; }

        [JsonProperty("parent")]
        public long Parent { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
