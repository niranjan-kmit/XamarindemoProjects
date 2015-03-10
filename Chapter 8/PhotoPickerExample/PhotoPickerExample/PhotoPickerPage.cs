using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Media;

namespace PhotoPickerExample
{
	public class PhotoPickerPage : ContentPage
	{
		Image image;

		public PhotoPickerPage ()
		{
			Label lblHeader = new Label
			{
				Text = "Photo Picker",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			image = new Image ();
			image.BackgroundColor = Color.Blue;
			image.Aspect = Aspect.AspectFit;
			image.HorizontalOptions = LayoutOptions.FillAndExpand;
			image.VerticalOptions = LayoutOptions.FillAndExpand;

			Button btnPickPhoto = new Button {
				Text = "Pick Photo"
			};
			btnPickPhoto.Clicked += (object sender, EventArgs e) => PickPhoto ();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					btnPickPhoto,
					image
				}
			};

		}

		private async void PickPhoto()
		{
			var mediaPicker = DependencyService.Get<IMediaPicker> ();
			var mediaFile = await mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions {
				DefaultCamera = CameraDevice.Front
			});
			image.Source = ImageSource.FromStream (() => mediaFile.Source); //result.Path;
		}

	}

}

