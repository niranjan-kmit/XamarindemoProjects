using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace ListPickerExample.Android
{
	[Activity (Label = "ListPickerExample.Android.Android", MainLauncher = true, ConfigurationChanges =  ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (App.GetMainPage ());
		}
	}
}

