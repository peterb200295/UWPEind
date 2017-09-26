using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpEindopdracht.Models;
using UwpEindopdracht.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpEindopdracht.Views
{
	/// <summary>
	/// Details on news article
	/// </summary>
	public sealed partial class ArticleDetails : Page
	{
		private ArticleDetailViewModel VM => ArticleDetailViewModel.SingleInstance;

		public ArticleDetails()
		{
			this.InitializeComponent();
			DataContext = this;
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			var article = e.Parameter as Article;

			if (article != null) {
				VM.Article = article;
			}
		}

		private async void OnReadMoreClick(object sender, RoutedEventArgs e)
		{
			Article article = (Article)sender;
			if (article==null)
			{
				return;
			}
			var uri = new Uri(article.Url);

			var success = await Windows.System.Launcher.LaunchUriAsync(uri);
		}
	}
}
