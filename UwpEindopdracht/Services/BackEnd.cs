using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using UwpEindopdracht.Models;
using System.Collections.Generic;
using Windows.UI.Popups;
using UwpEindopdracht.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using UwpEindopdracht.ViewModels;

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
				if (UserModel.Instance.IsLoggedIn)
				{
					client.DefaultRequestHeaders.Add("x-authtoken", UserModel.Instance.AuthenticationToken);
				}
				var json = await client.GetStringAsync(baseAPI + "Articles");
				var result = JsonConvert.DeserializeObject<ArticlesResult>(json);
				return result;
			}

		}

		public static async Task<bool> LikeArticle(int articleID)
		{
			var uri = baseAPI + "Articles/" + articleID + "//like";
			var authtoken = UserModel.Instance.AuthenticationToken;

			if (string.IsNullOrWhiteSpace(authtoken))
			{
				return false;
			}

			using (var client = new HttpClient())
			{
				using (var request = new HttpRequestMessage(HttpMethod.Put, uri))
				{
					request.Headers.Add("x-authtoken", authtoken);

					using (var response = await client.SendAsync(request))
					{
						var str = await response.Content.ReadAsStringAsync();
						return true;
					}
				}
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
				if (UserModel.Instance.IsLoggedIn)
				{
					client.DefaultRequestHeaders.Add("x-authtoken", UserModel.Instance.AuthenticationToken);
				}
				var json = await client.GetStringAsync(baseAPI + "Articles/" + nextId);
				var result = JsonConvert.DeserializeObject<ArticlesResult>(json);
				return result;
			}

		}

		public static async Task<bool> LoginUser(UserModel loginCredentials)
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
							
							return false;
						}

						dynamic authToken = JsonConvert.DeserializeObject(token);
						loginCredentials.AuthenticationToken = authToken.AuthToken;

						loginCredentials.Password = null;


						((Frame)Window.Current.Content).Navigate(typeof(MainPage));
						NewsViewModel.SingleInstance.RefreshArticles();

						return true;
					}
				}
			}


		}
	}
}