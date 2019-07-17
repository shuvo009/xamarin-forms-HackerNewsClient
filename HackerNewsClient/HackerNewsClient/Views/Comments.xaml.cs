using CommonServiceLocator;
using HackerNewsClient.Core.Models;
using HackerNewsClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackerNewsClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Comments : ContentPage
    {
        private ItemModel _selectedItem;
        public Comments(ItemModel item)
        {
            StoryCommentsViewModel storyCommentsViewModel = ServiceLocator.Current.GetInstance<StoryCommentsViewModel>();
            InitializeComponent();
            _selectedItem = item;
            BindingContext = storyCommentsViewModel;
            storyCommentsViewModel.LoadStoryCommentsCommand.Execute(_selectedItem.Kids);
        }
       
    }
}