using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsClient.Repository.DbModel
{
    public class ItemCommentDbModel : RealmObject
    {
        public string By { get; set; }   
        public long Id { get; set; }
        //public long[] Kids { get; set; }
        public long Parent { get; set; }
        public string Text { get; set; }
        public long Time { get; set; }
        public string Type { get; set; }

    }
}
