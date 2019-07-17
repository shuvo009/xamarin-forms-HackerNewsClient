using HackerNewsClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsClient.Core.Interface
{
    public interface IStoryCommentsRepository : IGenericRepository<ItemCommentModel>
    {
    }
}
