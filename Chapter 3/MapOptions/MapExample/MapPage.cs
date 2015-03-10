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
		private Slider slZoom;
		private Entry txtAddress;

		public MapPage ()
		{
			Label lblMap = new Label {
				Text = "Map of New York City",
				Font = Font.SystemFontOfSize (NamedSize.Large),
				TextColor = Color.Black
			};

			txtAddress = new Entry {
				Placeholder = "Enter an address",
				Text = "Madison Avenue New York, New York",
				TextColor = Color.Black
			};

			Button btnSearch = new Button {
				Text = "Go"
			};
			btnSearch.Clicked += (object sender, EventArgs e) => {
				GoToAddress (txtAddress.Text);
				txtAddress.Unfocus();
			};

			slZoom = new Slider (1, 18, 1);
			slZoom.Value = 10;
			slZoom.ValueChanged += (sender, e) => {
				double zoomLevel = e.NewValue; // between 1 and 18
				double latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				map.MoveToRegion(new MapSpan (map.VisibleRegion.Center, latlongdegrees, latlongdegrees)); 
			};

			map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(40,-100), Distance.FromMiles(1000))) {
				IsShowingUser = false,
				MapType = MapType.Street,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			StackLayout stackLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					lblMap,
					txtAddress,
					btnSearch,
					slZoom,
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

				double latlongdegrees = 360 / (Math.Pow(2, slZoom.Value));
				map.MoveToRegion (new MapSpan (position, latlongdegrees, latlongdegrees));
//				map.MoveToRegion (MapSpan.FromCenterAndRadius (
//					position, Distance.FromMiles (5.0)));

				map.Pins.Clear ();
				var pin = new Pin {
					Type = PinType.Place,
					Position = position,
					Label = "Search Result",
					Address = txtAddress.Text
				};
				map.Pins.Add(pin);

				break;
			}
		}
	}
}

