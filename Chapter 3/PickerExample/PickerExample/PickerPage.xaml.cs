using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PickerExample
{	
	public partial class PickerPage : ContentPage
	{	
		public PickerPage ()
		{
			InitializeComponent ();
			dtPicker.MinimumDate = new DateTime (2014, 11, 1);
			dtPicker.MaximumDate = new DateTime (2014, 12, 31);
		}

		protected void dtPickerDateSelected(object sender, DateChangedEventArgs e)
		{
			DisplayAlert ("Date Selected", dtPicker.Date.ToString("MM/dd/yyyy"), "OK", null);
		}

		protected void btnSubmitClicked(object sender, EventArgs e)
		{
			DateTime dt = dtPicker.Date + tiPicker.Time;
			string date = dt.ToString ("MM/dd/yyyy hh:mm tt");
			DisplayAlert ("Submitted", date, "OK", null);
		}
	}
}

