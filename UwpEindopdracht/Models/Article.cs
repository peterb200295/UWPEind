using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UwpEindopdracht.Services;

namespace UwpEindopdracht.Models
{
	public sealed class Article
    {
        public int Id { get; set; }
        public int Feed { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public List<string> Related { get; set; }
        public List<Category> Categories { get; set; }
        public bool IsLiked { get; set; }

		public async Task<bool> LikeArticle()
		{
			var succes = await Backend.LikeArticle(Id);

			if (succes == true)
			{
				IsLiked = true;
				return true;
			}
			else { return false; }
		}
	}
}
