using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ButtonExample
{	
	public partial class LoginPage : ContentPage
	{	
		public LoginPage ()
		{
			InitializeComponent ();
		}

		void txtPasswordChanged (object sender, TextChangedEventArgs e)
		{
			Entry txtPassword = sender as Entry;
			string password = txtPassword.Text;
		}

		void btnLoginClicked (object sender, EventArgs e)
		{
			DisplayAlert ("Login", "Your have logged in as " + this.txtUserName, "OK", null);
		}

		void btnCancelClicked (object sender, EventArgs e)
		{

		}

	}
}

