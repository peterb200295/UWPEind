using Exercise4.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpEindopdracht.Helpers;
using UwpEindopdracht.Models;
using UwpEindopdracht.Services;
using UwpEindopdracht.Views;
using Windows.ApplicationModel.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpEindopdracht.ViewModels
{
	public sealed class NewsViewModel
	{
		public static NewsViewModel SingleInstance { get; } = new NewsViewModel();

		public ObservableIncrementalLoadingCollection<Article> Articles { get; set; }

		private int _nextId;

		public RelayCommand ArticleOnClick { get; }
		public RelayCommand ArticleLikeOnClick { get; }
		public RelayCommand LogIn { get; set; }

		public UserModel User { get; }

		private NewsViewModel()
		{
			ArticleOnClick = new RelayCommand(NavigateToDetailsPage);
			ArticleLikeOnClick = new RelayCommand(LikeArticle);
			LogIn = new RelayCommand(LogInUser);

			User = UserModel.Instance;

			Articles = new ObservableIncrementalLoadingCollection<Article>();
			Articles.LoadMoreItemsAsyncEvent += ListOfItemsOnLoadMoreItemsAsyncEvent;
		}

		private async void LogInUser(object obj)
		{
			UserModel loginCredentials = (UserModel)obj;
			if (loginCredentials == null) return;

			Backend.LoginUser(loginCredentials);
			RefreshArticles();
		}

		private async Task<ObservableIncrementalLoadingCollection<Article>> ListOfItemsOnLoadMoreItemsAsyncEvent(int requestId)
		{
			ArticlesResult result = null;

			try
			{
				if (_nextId <= 0)
				{
					result = await Backend.GetDataFromBackendAsync();
				}
				else
					result = await Backend.GetDataFromBackendAsync(_nextId);
			}
			catch (Exception)
			{
				CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					var dialog = new MessageDialog("Er is een probleem opgetreden, probeer het opnieuw");
					var a = dialog.ShowAsync();
				}).AsTask();
				return null;
			}

			ObservableIncrementalLoadingCollection<Article> list = new ObservableIncrementalLoadingCollection<Article>();
			foreach (var item in result.Results)
			{
				list.Add(item);
			}
			_nextId = result.NextId;
			return list;

		}

		public void Logout()
		{
			var result = User.Logout();
			RefreshArticles();
		}

		//public RelayCommand NavigateToSecondPageCommand { get; } = new RelayCommand(NavigateToSecondPage);

		public void NavigateToDetailsPage(object article)
		{
			Article news = (Article)article;

			((Frame)Window.Current.Content).Navigate(typeof(ArticleDetails), news);
		}

		public async void LikeArticle(object article)
		{
			Article news = (Article)article;

			if (User.IsLoggedIn)
			{
				if (!news.IsLiked)
				{
					var result = await news.LikeArticle();
					RefreshArticles();
				}
			}
		}

		public async void RefreshArticles()
		{
			_nextId = -1;
			Articles.Clear();// = new ObservableIncrementalLoadingCollection<Article>();
			await Articles.LoadMoreItemsAsync(0);//Articles = await ListOfItemsOnLoadMoreItemsAsyncEvent(0);
		}
	}
}
