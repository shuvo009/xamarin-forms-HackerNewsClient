using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Repository.Helpers;
using Realms;

namespace HackerNewsClient.Repository
{
    public abstract class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class
        where TModel : RealmObject
    {
        public virtual async Task Insert(List<TEntity> models)
        {
            var realmDb = Realm.GetInstance(RealmHelper.GetRealmConfiguration());

            await realmDb.WriteAsync((rm) =>
            {
                foreach (var entity in models)
                {
                    var tModel = Mapper.Map<TEntity, TModel>(entity);
                    rm.Add(tModel);
                }
            });
        }


        public List<TEntity> GetAll()
        {
            var realmDb = Realm.GetInstance(RealmHelper.GetRealmConfiguration());
            var models = realmDb.All<TModel>().ToList();
            return models.Select(Mapper.Map<TModel, TEntity>).ToList();
        }
    }
}
