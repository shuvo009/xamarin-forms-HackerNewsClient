using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HackerNewsClient.ViewModels
{
    public class StoryCommentsViewModel : BaseViewModel
    {
        private readonly IStoryService storyService;
        private readonly IStoryCommentsRepository storyCommentsRepository;
        private readonly ICrashReportService crashReportService;

        public ICommand LoadStoryCommentsCommand { get; private set; }
        public ObservableCollection<ItemCommentModel> CommentItems { get; private set; }


        public StoryCommentsViewModel(IStoryService storyService, IStoryCommentsRepository storyCommentsRepository, ICrashReportService crashReportService)
        {
            this.storyService = storyService;
            this.storyCommentsRepository = storyCommentsRepository;
           
            this.crashReportService = crashReportService;
            CommentItems = new ObservableCollection<ItemCommentModel>();
            LoadStoryCommentsCommand = new Command<List<long>>(ExecuteLoadStoryCommentCommand);


        }

        #region Command Executions
        private async void ExecuteLoadStoryCommentCommand(List<long> ids)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {

                var storiesDb = storyCommentsRepository.GetAll(ids);
                foreach (var story in storiesDb)
                {
                    CommentItems.Add(story);
                }

                var comments = await storyService.GetCommentList(ids);
                CommentItems.Clear();
                foreach (var comment in comments)
                {
                    CommentItems.Add(comment);
                }
            }
            catch (Exception exception)
            {
                await crashReportService.ReportException(exception);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
