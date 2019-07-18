using AutoMapper;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using HackerNewsClient.Repository.DbModel;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsClient.Repository
{
    public class StoryCommentRepository : GenericRepository<ItemCommentModel, ItemCommentDbModel>, IStoryCommentsRepository
    {
        public List<ItemCommentModel> GetAll(List<long> ids)
        {
            var realmDb = GetRealmInstance();
            var dbComments = realmDb.All<ItemCommentDbModel>().ToList();
            var comments = new List<ItemCommentDbModel>();
            foreach (var id in ids)
            {
                var comment = dbComments.FirstOrDefault(x => x.Id == id);
                if (comment != null)
                    comments.Add(comment);
            }
            return comments.Select(Mapper.Map<ItemCommentDbModel, ItemCommentModel>).ToList();
        }

        public override Task Insert(List<ItemCommentModel> models)
        {
            //var realmDb = Realm.GetInstance(RealmHelper.GetRealmConfiguration());
            //using (var trans = realmDb.BeginWrite())
            //{
            //    realmDb.RemoveAll<ItemCommentDbModel>();
            //    trans.Commit();
            //}
            return base.Insert(models);
        }
    }
}
