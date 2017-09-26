using Exercise4.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpEindopdracht.Models;

namespace UwpEindopdracht.ViewModels
{
	public class ArticleDetailViewModel
	{
		//Properties
		public Article Article { get; set; }

		//Singleton
		public static ArticleDetailViewModel SingleInstance { get; } = new ArticleDetailViewModel();

		public RelayCommand OpenArticle { get; }

		private ArticleDetailViewModel()
		{
			OpenArticle = new RelayCommand(OpenArticleInBrowser);
		}

		private async void OpenArticleInBrowser(object obj)
		{
			var uri = new Uri((String)obj);
			if (uri != null)
			{
				var result = await Windows.System.Launcher.LaunchUriAsync(uri);
			}
		}
	}
}
