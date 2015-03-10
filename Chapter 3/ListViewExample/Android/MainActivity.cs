﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;


namespace ListViewExample.Android
{
	[Activity (Label = "ListViewExample.Android.Android", MainLauncher = true, ConfigurationChanges =  ConfigChanges.Orientation)]
	public class MainActivity :FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage(App.GetMainPage());



		}
	}
}

