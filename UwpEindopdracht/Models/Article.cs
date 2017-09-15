using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpEindopdracht.Models
{
    class Article
    {
        public int ArticleID { get; set; }

        public int FeedID { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string PublishDate { get; set; } //TODO: Parse to DateTime using newtonsomething

        public string ImageURL { get; set; }

        public string ArticleURL { get; set; }

        public List<Category> Categories { get; set; }

        public bool IsLiked { get; set; }
    }
}
