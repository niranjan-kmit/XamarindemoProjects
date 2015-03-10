using System;
using Xamarin.Forms;

namespace WebViewExample
{
	public class WebViewPage : ContentPage
	{
		private Entry txtAddress;
		private WebView webView;

		public WebViewPage ()
		{
			Label lblHeader = new Label {
				Text = "WebView",
				Font = Font.BoldSystemFontOfSize (NamedSize.Large),
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.Center
			};

			txtAddress = new Entry {
				TextColor = Color.Black,
				Text = "http://mooseworkssoftware.com"
			};

			Button btnGo = new Button {
				Text = "Go"
			};
			btnGo.Clicked += (object sender, EventArgs e) => {
				webView.Source = new UrlWebViewSource {
					Url = txtAddress.Text
				};
			};

			StackLayout addressStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					txtAddress,
					btnGo
				}
			};

			webView = new WebView {
				Source = new UrlWebViewSource {
				Url = "http://mooseworkssoftware.com/",
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			StackLayout stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					lblHeader,
					addressStack,
					webView,
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

