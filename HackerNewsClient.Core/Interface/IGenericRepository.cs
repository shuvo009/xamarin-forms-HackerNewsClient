using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsClient.Core.Interface
{
    public interface IGenericRepository<TEntity>
    {
        Task Insert(List<TEntity> models);
        List<TEntity> GetAll();
    }
}
