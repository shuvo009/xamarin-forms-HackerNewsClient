using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsClient.Core.Classes
{
    public static class ApiConstant
    {
        public const string TopStoryUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
        public const string DetailsUrl = "https://hacker-news.firebaseio.com/v0/item/{0}.json?print=pretty";
    }
}
