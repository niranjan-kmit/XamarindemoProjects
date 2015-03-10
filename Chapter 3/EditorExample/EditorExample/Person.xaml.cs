using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EditorExample
{	
	public partial class Person : ContentPage
	{	
		Picker picker;
		public Person ()
		{
			 picker = new Picker ();
			picker.Title = "MyphoneTitle";
		}

		protected void btnSubmitClicked(object sender, EventArgs e)
		{

			DisplayAlert ("Description", "test", "OK", null);

		}

	}
}

