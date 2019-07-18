using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using HackerNewsClient.Repository.DbModel;

using Realms;

namespace HackerNewsClient.Repository
{
    public class StoryRepository : GenericRepository<ItemModel, ItemDbModel>, IStoryRepository
    {
        public override Task Insert(List<ItemModel> models)
        {
            var realmDb = GetRealmInstance();
            using (var trans = realmDb.BeginWrite())
            {
                realmDb.RemoveAll<ItemDbModel>();
                trans.Commit();
            }
            return base.Insert(models);
        }
    }
}
