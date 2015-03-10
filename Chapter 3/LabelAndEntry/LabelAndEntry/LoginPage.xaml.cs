using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LabelAndEntry
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
	}
}

