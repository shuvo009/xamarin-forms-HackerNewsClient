using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;

namespace HackerNewsClient.Service.AppServices
{
    public class StoryService : IStoryService
    {
        private readonly IHackerNewsService _hackerNewsService;
        private readonly IStoryRepository _storyRepository;
        private readonly ITextToSpeech _textToSpeech;

        public StoryService(IHackerNewsService hackerNewsService, IStoryRepository storyRepository, ITextToSpeech textToSpeech)
        {
            _hackerNewsService = hackerNewsService;
            _storyRepository = storyRepository;
            _textToSpeech = textToSpeech;
        }

        public async Task<List<ItemModel>> GetStoryList()
        {
            var items = await _hackerNewsService.GetStoryList();
            await _storyRepository.Insert(items);
            _textToSpeech.Speak();
            return items;
        }
    }
}
