using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace JsonWriteExample
{
	public class JsonPage : ContentPage
	{
		private TableView tblContacts;
		private List<Contact> Contacts;

		public JsonPage ()
		{
			Label lblHeader = new Label
			{
				Text = "JSON",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			tblContacts = new TableView {
				Intent = TableIntent.Data,
				Root = new TableRoot ("Contacts")
			};
					
			Button btnReadContacts = new Button {
				Text = "Read Contacts"
			};
			btnReadContacts.Clicked += (object sender, EventArgs e) => ReadContacts ();

			Button btnUpdateContacts = new Button {
				Text = "Update Contacts"
			};
			btnUpdateContacts.Clicked += (object sender, EventArgs e) => UpdateContacts();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
			this.BackgroundColor = Color.White;

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					btnReadContacts,
					btnUpdateContacts,
					tblContacts
				}
			};

		}

		private async void ReadContacts()
		{
			/*var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri ("http://192.168.1.10/EntitiesModelService.svc");
			var response = await client.GetAsync("GetContacts");
			string jsonString = response.Content.ReadAsStringAsync ().Result;*/

			// for debug only
			string jsonString = "{\"GetContactsResult\":[{\"DisplayName\":\"Keith Welch\",\"FirstName\":\"Keith\",\"ID\":1,\"LastName\":\"Welch\",\"MiddleName\":null,\"Password\":\"moose\",\"Picture\":\"KeithWelch.jpg\",\"Title\":null,\"UserName\":\"keith\"},{\"DisplayName\":\"Jane Doe\",\"FirstName\":\"Jane\",\"ID\":1,\"LastName\":\"Doe\",\"MiddleName\":null,\"Password\":\"jd\",\"Picture\":null,\"Title\":null,\"UserName\":\"jd\"}]}";

			ContactsResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactsResult> (jsonString);
			Contacts = result.GetContactsResult;

			TableSection section = new TableSection("Contacts");

			foreach (Contact contact in Contacts)
			{
		section.Add (new TextCell {
					Text = contact.DisplayName,
					TextColor = Color.Black,
					Detail = contact.UserName,
					DetailColor = Color.Navy
				                 });
			}
			tblContacts.Root.Add(new TableSection[]{section});
		}

		private async void UpdateContacts()
		{
			foreach (Contact contact in Contacts)
			{
				contact.Picture = contact.DisplayName.Replace(" ", "") + "jpg";


			}

			var settings = new Newtonsoft.Json.JsonSerializerSettings (){ DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat };
			string jsonContacts = Newtonsoft.Json.JsonConvert.SerializeObject (Contacts, settings);
			string json = "{\"Contacts\":" + jsonContacts + "}";
			var content  = new StringContent(json, System.Text.Encoding.UTF8, "text/json");

			var client = new HttpClient ();
			client.BaseAddress = new Uri ("http://192.168.1.10:86/EntitiesModelService.svc");


			var response = await client.PostAsync("SaveContacts", content);

		}

	}

}

