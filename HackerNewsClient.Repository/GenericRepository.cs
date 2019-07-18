using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HackerNewsClient.Core.Interface;

using Realms;

namespace HackerNewsClient.Repository
{
    public abstract class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity : class
        where TModel : RealmObject
    {

      
        public virtual async Task Insert(List<TEntity> models)
        {
            var realmDb = GetRealmInstance();

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
            var realmDb = GetRealmInstance();
            var models = realmDb.All<TModel>().ToList();
            return models.Select(Mapper.Map<TModel, TEntity>).ToList();
        }

        #region Internal Methods
        internal Realm GetRealmInstance()
        {
            var config = new RealmConfiguration() { SchemaVersion = 1 };
            var realm = Realm.GetInstance(config);
            return realm;
        }
        #endregion


    }
}
