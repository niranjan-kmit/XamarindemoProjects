using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ListViewOptions.Android;

[assembly: ExportRenderer (typeof (Button), typeof (ListButtonRenderer))]


namespace ListViewOptions.Android
{
	public class ListButtonRenderer : ButtonRenderer
	{

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			Control.Focusable = false;
		}
	}
}


