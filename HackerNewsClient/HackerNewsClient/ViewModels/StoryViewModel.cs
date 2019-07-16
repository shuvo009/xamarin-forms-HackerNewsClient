using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using Xamarin.Forms;

namespace HackerNewsClient.ViewModels
{
    public class StoryViewModel : BaseViewModel
    {
        private readonly IStoryService _storyService;
        private readonly IStoryRepository _storyRepository;
        private readonly ICrashReportService _crashReportService;


        public ICommand LoadStoryCommand { get; private set; }
        public ObservableCollection<ItemModel> StoryItems { get; private set; }

        public StoryViewModel(IStoryService storyService, IStoryRepository storyRepository, ICrashReportService crashReportService)
        {
            _storyService = storyService;
            _storyRepository = storyRepository;
            _crashReportService = crashReportService;
            StoryItems = new ObservableCollection<ItemModel>();
            InitCommands();
        }

        #region Command Executions

        private async Task ExecuteLoadStoryCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                StoryItems.Clear();
                var storiesDb = _storyRepository.GetAll();
                foreach (var story in storiesDb)
                {
                    StoryItems.Add(story);
                }
                
              
                var stories = await _storyService.GetStoryList();
                StoryItems.Clear();
                foreach (var story in stories)
                {
                    StoryItems.Add(story);
                }
            }
            catch (Exception exception)
            {
                await _crashReportService.ReportException(exception);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Supported Methods

        private void InitCommands()
        {
            LoadStoryCommand = new Command(async () => await ExecuteLoadStoryCommand());
        }

        #endregion
    }
}
