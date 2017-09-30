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
			bool succes;
			UserModel loginCredentials = (UserModel)obj;
			if (loginCredentials == null) return;

			try
			{
				succes = await Backend.LoginUser(loginCredentials);

				if (!succes)
				{
					ShowPopup("De ingevoerde gebruikersnaam/wachtwoord is incorrect.");
					return;
				}
				else
				{
					ShowPopup("Ingelogd als " + UserModel.Instance.UserName);
					RefreshArticles();
				}
			}
			catch (Exception)
			{
				ShowPopup("Er lijkt een probleem opgetreden te zijn. Probeer het later opnieuw.");
				return;
			}
		}

		private async void ShowPopup(string message)
		{
			var dialog = new MessageDialog(message);
			await dialog.ShowAsync();
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

				ObservableIncrementalLoadingCollection<Article> list = new ObservableIncrementalLoadingCollection<Article>();
				foreach (var item in result.Results)
				{
					list.Add(item);
				}
				_nextId = result.NextId;
				return list;
			}
			catch (Exception)
			{
				await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					var dialog = new MessageDialog("Er is een probleem opgetreden met de verbinding, klik op de refresh knop op het opnieuw te proberen");
					var a = dialog.ShowAsync();
				}).AsTask();

				Articles.ClearEvents();
				//Articles.LoadMoreItemsAsyncEvent -= ListOfItemsOnLoadMoreItemsAsyncEvent;

				return null;
			}
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

		//TODO: ERRORHANDLING
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
			Articles.Clear();

			Articles.ClearEvents();
			Articles.LoadMoreItemsAsyncEvent += ListOfItemsOnLoadMoreItemsAsyncEvent;

			await Articles.LoadMoreItemsAsync(0);
		}
	}
}
