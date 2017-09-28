using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UwpEindopdracht.Helpers;

namespace UwpEindopdracht.Models
{
	public class UserModel : INotifyPropertyChanged
	{
		private string username;
		private string password;
		private string authToken;

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string UserName {
			get { return username; }
			set {
				if (value != username)
				{
					username = value;
					NotifyPropertyChanged("UserName");
				}
			}
		}

		public string Password {
			get { return password; }
			set {
				if (value != password)
				{
					password = value;
					NotifyPropertyChanged("Password");
				}
			}
		}

		public string AuthenticationToken {
			get { return authToken; }
			set {	
				if (value != authToken)
				{
					authToken = value;
					NotifyPropertyChanged("AuthenticationToken");
				}
			}
		}

		public bool IsLoggedIn {
			get {
				if (string.IsNullOrWhiteSpace(authToken)) { return false; }
				else return true;
			}
		}

		public static UserModel Instance { get; } = new UserModel();
		public bool IsValid()
		{
			bool correct = true;

			if (String.IsNullOrWhiteSpace(UserName)) { correct = false; }
			if (String.IsNullOrWhiteSpace(Password)) { correct = false; }

			return correct;
		}

		private UserModel()
		{
			Password = "";
			UserName = "";
			AuthenticationToken = null;
		}
	}
}
