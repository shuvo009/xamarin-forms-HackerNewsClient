using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Models;

namespace HackerNewsClient.Core.Interface
{
    public interface IHackerNewsService
    {
        Task<List<ItemModel>> GetStoryList();
        Task<List<ItemModel>> GetComments(List<long> ids);
    }
}
