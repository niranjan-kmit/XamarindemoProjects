using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapExample
{
	public class MapPage : ContentPage
	{
		// steps needed for map support:
		// Add Xamarin.Forms.Maps package to all projects
		// Add Xamarin.FormsMaps.Init(); to:
			// Android: MainActivity.cs - OnCreate method
			// iOS: AppDelegate.cs - FinishedLaunching method
		// Add following to iOS Info.plist (for iOS8
			// <key>NSLocationAlwaysUsageDescription</key>
			// <string>Ask to allow location message</string>
			// <key>NSLocationWhenInUseUsageDescription</key>
			// <string>Location is being used message</string>
		// for Android, you need a map api key, see
		// http://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/

		private Map map;

		public MapPage ()
		{
			Label lblMap = new Label {
				Text = "Map of New York City",
				Font = Font.SystemFontOfSize (NamedSize.Large),
				TextColor = Color.Black
			};

			map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(40,-100), Distance.FromMiles(1000))) {
				IsShowingUser = false,
//				HeightRequest = 100,
//				WidthRequest = 960,
				MapType = MapType.Street,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			StackLayout stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					lblMap,
					map
				}
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
			this.BackgroundColor = Color.White;

			// Build the page.
			this.Content = stackLayout;

			GoToAddress("Madison Avenue New York, New York");
		}

		private async void GoToAddress(string Address)
		{
			Geocoder geocoder = new Geocoder ();
			Task<IEnumerable<Position>> result =
				geocoder.GetPositionsForAddressAsync (Address);

			IEnumerable<Position> data = await result;
			foreach (Position position in data) {
				map.MoveToRegion (MapSpan.FromCenterAndRadius (
					position, Distance.FromMiles (5.0)));
				break;
			}
		}
	}
}

