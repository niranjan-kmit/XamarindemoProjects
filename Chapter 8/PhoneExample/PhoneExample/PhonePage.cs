using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using System.Threading.Tasks;

namespace PhoneExample
{
	public class PhonePage : ContentPage
	{
		Entry txtPhoneNumber;

		public PhonePage ()
		{
			Label lblHeader = new Label
			{
				Text = "Phone",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			txtPhoneNumber = new Entry {
				Placeholder = "Number to call"
			};

			Button btnPhone = new Button {
				Text = "Make a Call"
			};
			btnPhone.Clicked += (object sender, EventArgs e) => MakeACall ();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					txtPhoneNumber,
					btnPhone
				}
			};

		}

		private void MakeACall()
		{
			var phoneService = DependencyService.Get<IPhoneService> ();
			phoneService.DialNumber (txtPhoneNumber.Text);
		}

	}

}

