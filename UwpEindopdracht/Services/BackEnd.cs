using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UwpEindopdracht.Services
{
	static class Backend
	{
		private static readonly string baseAPI = "http://inhollandbackend.azurewebsites.net/api/";

		/// <summary>
		/// Get articles Async for first load
		/// </summary>
		/// <returnsArticlesResult></returns>
		public static async Task<ArticlesResult> GetDataFromBackendAsync()
		{
			using (var client = new HttpClient())
			{
				var json = await client.GetStringAsync(baseAPI + "Articles");
				var result = JsonConvert.DeserializeObject<ArticlesResult>(json);
				return result;
			}
		}

		/// <summary>
		/// Get articles Async for incremental loading
		/// </summary>
		/// <param name="nextId"></param>
		/// <returns></returns>
		public static async Task<ArticlesResult> GetDataFromBackendAsync(int nextId)
		{
			using (var client = new HttpClient())
			{
				var json = await client.GetStringAsync(baseAPI + "Articles/" + nextId);
				var result = JsonConvert.DeserializeObject<ArticlesResult>(json);
				return result;
			}
		}
	}
}
