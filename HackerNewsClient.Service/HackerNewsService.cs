using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Classes;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;

namespace HackerNewsClient.Service
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IRestService _restService;

        public HackerNewsService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<List<ItemModel>> GetStoryList()
        {
            var topStories = await GetTopStories();
            return await GetItems(topStories);
        }

        public Task<List<ItemCommentModel>> GetComments(List<long> ids)
        {
            return GetItemComments(ids);
        }

        #region Supported Methods

        private async Task<List<long>> GetTopStories()
        {
            var topStories = await _restService.Get<List<long>>(ApiConstant.TopStoryUrl);
            return topStories.Take(10).ToList();
        }

        private async Task<ItemModel> GetDetails(long id)
        {
            var url = String.Format(ApiConstant.DetailsUrl, id);
            var storyModel = await _restService.Get<ItemModel>(url);
            return storyModel;
        }
        private async Task<ItemCommentModel> GetCommentDetails(long id)
        {
            var url = String.Format(ApiConstant.DetailsUrl, id);
            var commentModel = await _restService.Get<ItemCommentModel>(url);
            return commentModel;
        }
        private async Task<List<ItemModel>> GetItems(List<long> ids)
        {
            var itemModels = new List<ItemModel>();
            foreach (var id in ids)
            {
                var storyModel = await GetDetails(id);
                itemModels.Add(storyModel);
            }

            return itemModels;
        }
        private async Task<List<ItemCommentModel>> GetItemComments(List<long> ids)
        {
            var itemCommentModel = new List<ItemCommentModel>();
            foreach (var id in ids)
            {
                var storyComment = await GetCommentDetails(id);
                itemCommentModel.Add(storyComment);
            }

            return itemCommentModel;
        }

       

        #endregion
    }
}
