using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpEindopdracht.Models
{
	public class UserModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string AuthenticationToken { get; set; }

		public bool IsLoggedIn {
			get {
				if (string.IsNullOrWhiteSpace(AuthenticationToken)) { return false; }
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
		}
	}
}
