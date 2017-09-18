using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpEindopdracht.ViewModels
{
	public class ArticleDetailViewModel
	{
		//Properties
		public int ArticleId { get; set; }

		public string Title { get; set; }

		public string Summary { get; set; }

		public string ImageURL { get; set; }
		public string ArticleURL { get; set; }

		//Singleton
		public static ArticleDetailViewModel SingleInstance { get; } = new ArticleDetailViewModel();

		private ArticleDetailViewModel()
		{
			LoadArticle();
		}

		private void LoadArticle()
		{
			this.ArticleId = 2;
			this.ImageURL = "https://media.nu.nl/m/aq4xvuuax56y_std320.jpg";
			this.Title = "Unknown item";
			this.Summary = "Unknown item is in the news again!";

		}
	}
}
