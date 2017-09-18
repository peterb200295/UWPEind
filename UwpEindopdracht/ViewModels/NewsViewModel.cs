using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpEindopdracht.Helpers;
using UwpEindopdracht.Models;
using UwpEindopdracht.Services;

namespace UwpEindopdracht.ViewModels
{
    public sealed class NewsViewModel
    {
        public static NewsViewModel SingleInstance { get; } = new NewsViewModel();

        public ObservableIncrementalLoadingCollection<Article> Articles { get; set; }

		private int _nextId;

        private NewsViewModel()
        {
            //Articles.Add(new Article { Title = "Artikel 1", Summary = "Omschrijving", Image = "https://media.nu.nl/m/bx0xbrba7szq_std320.jpg" });
            //Articles.Add(new Article { Title = "Artikel 2", Summary = "Omschrijving", Image = "https://media.nu.nl/m/frxxeb7atkg3_std320.jpg" });
            //Articles.Add(new Article { Title = "Artikel 3", Summary = "Omschrijving", Image = "https://media.nu.nl/m/aq4xvuuax56y_std320.jpg" });
            //Articles.Add(new Article { Title = "Artikel 4", Summary = "Omschrijving", Image = "https://media.nu.nl/m/bx0xbrba7szq_std320.jpg" });
            //Articles.Add(new Article { Title = "Artikel 5", Summary = "Omschrijving", Image = "https://media.nu.nl/m/bx0xbrba7szq_std320.jpg" });

            Articles = new ObservableIncrementalLoadingCollection<Article>();
            //FillArticles();

            Articles.LoadMoreItemsAsyncEvent += ListOfItemsOnLoadMoreItemsAsyncEvent;
        }

        private async void FillArticles()
        {
           var result = await Backend.GetDataFromBackendAsync();
            foreach (var item in result.Results)
            {
                Articles.Add(item);
            }
			_nextId = result.NextId;
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
    }
}
