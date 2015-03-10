using System;
using Xamarin.Forms;

namespace NavigationPageExample
{
	public class PushPage : ContentPage
	{
		public PushPage ()
		{
			Label header = new Label
			{
				Text = "Push Page",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			Button btnReturn = new Button
			{
				Text = "Return",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			btnReturn.Clicked += async (object sender, EventArgs e) => 
			{
				await Navigation.PopAsync();
			};

			this.Content = new StackLayout {
				Children = {
					header,
					btnReturn
				}
			};
		}
	}
}

