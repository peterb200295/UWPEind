using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpEindopdracht.Models;
using UwpEindopdracht.Services;
using UwpEindopdracht.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpEindopdracht.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		private NewsViewModel VM => NewsViewModel.SingleInstance;

		public MainPage()
		{
			this.InitializeComponent();
			DataContext = VM;
			//NavigationCacheMode = NavigationCacheMode.Required;
		}

		private void ArticleSelection(object sender, ItemClickEventArgs e)
		{
			VM.ArticleOnClick.Execute(e.ClickedItem);
		}

		private void OnHamburgerClick(object sender, RoutedEventArgs e)
		{
			this.MySplitView.IsPaneOpen = !this.MySplitView.IsPaneOpen;
		}

		private async void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			UserModel.Instance.UserName = textb_Email.Text;
			UserModel.Instance.Password = textb_Password.Password;

			if (!UserModel.Instance.IsValid())
			{
				var dialog = new MessageDialog("Voer uw gegevens in");
				await dialog.ShowAsync();
				return;
			}

			VM.LogIn.Execute(UserModel.Instance);
		}

		private void LikeButton_Click(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			var article = (Article)button.DataContext;

			VM.ArticleLikeOnClick.Execute(article);
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
				AppViewBackButtonVisibility.Collapsed;
			MySplitView.IsPaneOpen = false;
		}

		private void LogoutButton_Click(object sender, RoutedEventArgs e)
		{
			VM.Logout();
		}

		private void RefreshButton_Click(object sender, RoutedEventArgs e)
		{
			VM.RefreshArticles();
		}

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            UserModel.Instance.UserName = textb_Email.Text;
            UserModel.Instance.Password = textb_Password.Password;

            if (!UserModel.Instance.IsValid())
            {
                var dialog = new MessageDialog("Voer uw gegevens in");
                await dialog.ShowAsync();
                return;
            }

            VM.Register.Execute(UserModel.Instance);
        }
    }
}
//Used resources
// - Hamburgermenu http://www.shenchauhan.com/blog/2015/7/14/creating-a-responsive-uwp-application
// - 