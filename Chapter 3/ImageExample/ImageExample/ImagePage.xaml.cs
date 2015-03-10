using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace ImageExample
{	
	public partial class ImagePage : ContentPage
	{	
		public ImagePage ()
		{
			InitializeComponent ();

			var assembly = typeof(ImagePage).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames()) 
				System.Diagnostics.Debug.WriteLine("found resource: " + res);

			ImageSource imageSource = ImageSource.FromResource("ImageExample.mooseworks.jpg");
			imgEmbedded.Source = imageSource;
			imgEmbedded.Aspect = Aspect.AspectFill;
			imgEmbedded.BackgroundColor = Color.Blue;
			imgRemote.Source = "http://mooseworkssoftware.com/wordpress/wp-content/uploads/2013/11/services1.png";
			imgRemote.Aspect = Aspect.AspectFit;
			imgRemote.BackgroundColor = Color.Blue;
		}
	}
}

