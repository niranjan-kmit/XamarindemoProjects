using System;
using Xamarin.Forms;

namespace NavigationPageExample
{
	public class NavPage : ContentPage
	{
		public NavPage ()
		{
			Label header = new Label
			{
				Text = "Navigation Page",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			Button btnPush = new Button
			{
				Text = "Push Page",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center,
				BorderWidth = 1
			};
			btnPush.Clicked += async (sender, args) =>
				await Navigation.PushAsync(new PushPage());

			Button btnModal = new Button
			{
				Text = "Modal Page",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				HorizontalOptions = LayoutOptions.Center,
				BorderWidth = 1
			};
			btnModal.Clicked += async (sender, args) =>
				await Navigation.PushModalAsync(new ModalPage());

			this.Content = new StackLayout {
				Children = {
					header,
					btnPush,
					btnModal,
				        }
			};
		}
	}
}

