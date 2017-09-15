using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace UwpEindopdracht.Services
{
    static class Backend
    {
        private static readonly string baseAPI = "http://inhollandbackend.azurewebsites.net/api/";

        public static async Task<ArticlesResult> GetDataFromBackendAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(baseAPI + "Articles");
                var result = JsonConvert.DeserializeObject<ArticlesResult>(json);
                return result;
            }
        }
    }
}
