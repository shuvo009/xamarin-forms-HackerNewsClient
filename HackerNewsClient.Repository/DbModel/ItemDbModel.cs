using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Realms;

namespace HackerNewsClient.Repository.DbModel
{
    public class ItemDbModel : RealmObject
    {
        public string By { get; set; }

        public string Descendants { get; set; }
     
        [PrimaryKey]
        public long Id { get; set; }

        //public RealmList<long> Kids { get; set; }

        //public RealmList<long> Parts { get; set; }

        public long Score { get; set; }
        
        public long Time { get; set; }
        
        public string Title { get; set; }
        
        public string Type { get; set; }
    }
}
