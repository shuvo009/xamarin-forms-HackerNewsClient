using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using HackerNewsClient.Repository.DbModel;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsClient.Repository
{
    public class StoryCommentRepository : GenericRepository<ItemCommentModel, ItemCommentDbModel>, IStoryCommentsRepository
    {
        public override Task Insert(List<ItemCommentModel> models)
        {
            var realmDb = Realm.GetInstance();
            using (var trans = realmDb.BeginWrite())
            {
                realmDb.RemoveAll<ItemCommentDbModel>();
                trans.Commit();
            }
            return base.Insert(models);
        }
    }
}
