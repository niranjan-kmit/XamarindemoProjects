using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using System.Threading.Tasks;

namespace SMSExample
{
	public class SMSPage : ContentPage
	{
		Entry txtPhoneNumber;
		Editor edSMS;

		public SMSPage ()
		{
			Label lblHeader = new Label
			{
				Text = "SMS",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			Label lblPhoneNumber = new Label
			{
				Text = "SMS",
				Font = Font.SystemFontOfSize(NamedSize.Large)
			};

			txtPhoneNumber = new Entry {
				Placeholder = "Number to message"
			};

			Label lblMessage = new Label
			{
				Text = "Enter message below",
				Font = Font.SystemFontOfSize(NamedSize.Large)
			};

			edSMS = new Editor ();

			Button btnSMS = new Button {
				Text = "Send Message"
			};
			btnSMS.Clicked += (object sender, EventArgs e) => SendSMS ();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					lblPhoneNumber,
					txtPhoneNumber,
					lblMessage,
					edSMS,
					btnSMS
				}
			};

		}

		private void SendSMS()
		{
			var phoneService = DependencyService.Get<IPhoneService> ();
			phoneService.SendSMS(txtPhoneNumber.Text, edSMS.Text);
		}

	}

}

