using System;
using Xamarin.Forms;

namespace NavigationPageExample
{
	public class ModalPage : ContentPage
	{
		public ModalPage ()
		{
			Label header = new Label
			{
				Text = "Modal Page",
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
				await Navigation.PopModalAsync();
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

