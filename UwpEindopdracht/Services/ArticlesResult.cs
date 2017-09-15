using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpEindopdracht.Helpers;
using UwpEindopdracht.Models;

namespace UwpEindopdracht.Services
{
    class ArticlesResult
    {
        public List<Article> Results { get; set; }
        public int NextId { get; set; }
    }
}
