using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Common.Models;
using Xamarin.Common.Services;
using Xamarin.Forms;

namespace Xamarin.UIForms.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Post> posts;
        private bool isRefreshing;
        public ObservableCollection<Post> Posts
        {
            get => this.posts;
            set => this.SetValue(ref this.posts, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public PostsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPosts();
        }

        private async void LoadPosts()
        {
            this.IsRefreshing = true;

            var response = await this.apiService.GetListAsync<Post>(
                "https://jsonplaceholder.typicode.com",
                "posts");

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var posts = (List<Post>)response.Result;
            this.Posts = new ObservableCollection<Post>(posts);
        }
    }
}
