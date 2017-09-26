using Exercise4.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpEindopdracht.Helpers;
using UwpEindopdracht.Models;
using UwpEindopdracht.Services;
using UwpEindopdracht.Views;
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

		private NewsViewModel()
		{
			ArticleOnClick = new RelayCommand(NavigateToDetailsPage);

			Articles = new ObservableIncrementalLoadingCollection<Article>();
			Articles.LoadMoreItemsAsyncEvent += ListOfItemsOnLoadMoreItemsAsyncEvent;
		}

		private async Task<ObservableIncrementalLoadingCollection<Article>> ListOfItemsOnLoadMoreItemsAsyncEvent(int requestId)
		{
			ArticlesResult result;
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

		//public RelayCommand NavigateToSecondPageCommand { get; } = new RelayCommand(NavigateToSecondPage);

		public void NavigateToDetailsPage(object article)
		{
			Article news = (Article)article;

			((Frame)Window.Current.Content).Navigate(typeof(ArticleDetails), news);
		}
	}
}
