using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpEindopdracht.Models;

namespace UwpEindopdracht.ViewModels
{
    class NewsViewModel
    {
        public List<Article> Articles { get; set; }

        public int NextID { get; set; }
    }
}
