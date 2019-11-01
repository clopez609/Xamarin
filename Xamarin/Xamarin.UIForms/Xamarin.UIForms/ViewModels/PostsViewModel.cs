using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Common.Models;
using Xamarin.Common.Services;
using Xamarin.Forms;

namespace Xamarin.UIForms.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private ObservableCollection<Post> _posts;
        private bool isRefreshing;
        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set => SetValue(ref this._posts, value);
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref this.isRefreshing, value);
        }

        public PostsViewModel()
        {
            _apiService = new ApiService();
            LoadPosts();
        }

        private async void LoadPosts()
        {
            IsRefreshing = true;

            var response = await _apiService.GetListAsync<Post>(
                "https://jsonplaceholder.typicode.com",
                "posts");

            IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var posts = (List<Post>)response.Result;
            Posts = new ObservableCollection<Post>(posts);
        }
    }
}
