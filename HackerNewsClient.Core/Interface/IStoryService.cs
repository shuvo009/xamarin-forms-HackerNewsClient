using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Models;

namespace HackerNewsClient.Core.Interface
{
    public interface IStoryService
    {
        Task<List<ItemModel>> GetStoryList();
    }
}
