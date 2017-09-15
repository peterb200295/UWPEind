using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpEindopdracht.Models
{
    public sealed class ArticlesResult<T>
    {
        public int NextId { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}