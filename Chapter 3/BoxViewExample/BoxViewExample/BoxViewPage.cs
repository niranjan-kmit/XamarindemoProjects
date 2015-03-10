using System;
using Xamarin.Forms;

namespace BoxViewExample
{
	public class BoxViewPage : ContentPage
	{
		public BoxViewPage ()
		{
			Label lblBox1 = new Label {
				Text = "Blue Box 200 x 100",
				Font = Font.SystemFontOfSize (NamedSize.Large),
				TextColor = Color.Black
			};

			BoxView boxView1 = new BoxView
			{
				Color = Color.Blue,
				WidthRequest = 200,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			Label lblBox2 = new Label {
				Text = "Red Box 50 x 250",
				Font = Font.SystemFontOfSize (NamedSize.Large),
				TextColor = Color.Black
			};

			BoxView boxView2 = new BoxView
			{
				Color = Color.Red,
				WidthRequest = 50,
				HeightRequest = 250,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			StackLayout stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					lblBox1,
					boxView1,
					lblBox2,
					boxView2,
				}
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
			this.BackgroundColor = Color.White;

			// Build the page.
			this.Content = stackLayout;
		}
	}
}

