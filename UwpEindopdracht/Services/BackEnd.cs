using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using UwpEindopdracht.Models;
using System.Collections.Generic;
using Windows.UI.Popups;

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

		public static async void LoginUser(UserModel loginCredentials)
		{
			using (var client = new HttpClient())
			{
				var parameters = new Dictionary<string, string> { { "username", loginCredentials.UserName }, { "password", loginCredentials.Password } };

				using (var content = new FormUrlEncodedContent(parameters))
				{
					using (var response = await client.PostAsync(baseAPI + "Users/Login", content))
					{
						var token = await response.Content.ReadAsStringAsync();

						if (string.IsNullOrWhiteSpace(token))
						{
							var dialog = new MessageDialog("De ingevoerde gebruikersnaam/wachtwoord is incorrect.");
							await dialog.ShowAsync();
						}

						dynamic authToken = JsonConvert.DeserializeObject(token);
						loginCredentials.AuthenticationToken = authToken.AuthToken;
					}
				}
			}
		}
	}
}