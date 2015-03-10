using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Media;

namespace CameraExample
{
	public class CameraPage : ContentPage
	{
		Image image;

		public CameraPage ()
		{
			Label lblHeader = new Label
			{
				Text = "Camera",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			image = new Image ();
			image.BackgroundColor = Color.Blue;
			image.Aspect = Aspect.AspectFit;
			image.HorizontalOptions = LayoutOptions.FillAndExpand;
			image.VerticalOptions = LayoutOptions.FillAndExpand;

			Button btnTakePhoto = new Button {
				Text = "Take Photo"
			};
			btnTakePhoto.Clicked += (object sender, EventArgs e) => TakePhoto ();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					btnTakePhoto,
					image
				}
			};

		}

		private async void TakePhoto()
		{
			var mediaPicker = DependencyService.Get<IMediaPicker> ();
			var mediaFile = await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions {
				DefaultCamera = CameraDevice.Front,
				MaxPixelDimension = 400,
				SaveMediaOnCapture = true
			});
			image.Source = ImageSource.FromStream (() => mediaFile.Source); //result.Path;
		}

	}

}

