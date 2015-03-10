using System;
using Xamarin.Forms;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace DatabaseAccessExample
{
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}

	public class DatabasePage : ContentPage
	{
		private SQLiteConnection database;

		public DatabasePage ()
		{
			Label lblHeader = new Label
			{
				Text = "Table View",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				HorizontalOptions = LayoutOptions.Center
			};

			Button btnCreateDatabase = new Button {
				Text = "Create Database"
			};
			btnCreateDatabase.Clicked += (object sender, EventArgs e) => CreateDatabase();

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

			this.Content = new StackLayout {
				Children = {
					lblHeader,
					btnCreateDatabase
				}
			};

		}

		private void CreateDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<Product> ();
            System.Console.WriteLine("check ");
		}
	}

	public class Product
	{
		public Product()
		{
		}

		public Product(string Name, string Category, bool InStock, string Description, string ImageUrl)
		{
			this.Name = Name;
			this.Category = Category;
			this.Description = Description;
			this.ImageUrl = ImageUrl;
			this.InStock = InStock;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { set; get; }
		public string Category { set; get; }
		public string Description { set; get; }
		public string ImageUrl { set; get; }
		public bool InStock { set; get; }

		public override string ToString()
		{
            return Name ;
                
		}
	}

}

