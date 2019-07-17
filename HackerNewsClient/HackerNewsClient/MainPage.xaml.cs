using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Core.Models;
using HackerNewsClient.ViewModels;
using HackerNewsClient.Views;
using Xamarin.Forms;

namespace HackerNewsClient
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly StoryViewModel _storyViewModel;
        public MainPage()
        {
            StoryViewModel storyViewModel = ServiceLocator.Current.GetInstance<StoryViewModel>();
            InitializeComponent();
            BindingContext = storyViewModel;
            _storyViewModel = storyViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_storyViewModel.StoryItems.Count <= 0)
                _storyViewModel.LoadStoryCommand.Execute(null);
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var item = e.SelectedItem as ItemModel;
            await Navigation.PushAsync(new Comments(item));
            listView.SelectedItem = null;
        }
    }
}
