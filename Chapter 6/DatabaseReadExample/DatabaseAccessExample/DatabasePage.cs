using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		private	Product[] products;
		ListView listproducts;

		public DatabasePage ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();

			Label lblHeader = new Label
			{
				Text = "Table View",
				Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.Center
			};

			TableView tableProducts = new TableView {
				Intent = TableIntent.Data,
				Root = new TableRoot ("Products and Services")
			};
			listproducts=new ListView
			{

				ItemsSource=products,
			};

			Button btnCreateDatabase = new Button {
				Text = "Create Database"
			};
			btnCreateDatabase.Clicked += (object sender, EventArgs e) => CreateDatabase();

			Button btnDeleteRecords = new Button {
				Text = "Delete Records"
			};
			btnDeleteRecords.Clicked += (object sender, EventArgs e) => DeleteRecords();

			Button btnWriteToDatabase = new Button {
				Text = "Write to Database"
			};
			btnWriteToDatabase.Clicked += (object sender, EventArgs e) => WriteToDatabase();

			Button btnReadDatabase = new Button {
				Text = "Read Database"
			};
			btnReadDatabase.Clicked += (object sender, EventArgs e) => ReadDatabase(tableProducts.Root);

			this.Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);
			this.BackgroundColor = Color.White;
			this.Content = new StackLayout {
				Children = {
					lblHeader,
					btnCreateDatabase,
					btnDeleteRecords,
					btnWriteToDatabase,
					btnReadDatabase,
					listproducts,
					//tableProducts,


				}
			};

		}

		private void CreateDatabase()
		{
			database.CreateTable<Product> ();
			DisplayAlert ("Success", "Database Created", "OK", "");
		}

		private void DeleteRecords()
		{
			database.DeleteAll<Product> ();
			DisplayAlert ("Success", "All Records Deleted", "OK", "");
		}

		private void WriteToDatabase()
		{
			products = new Product[]
			{
				new Product("Dev Services", "Service", true,
					"Do you need a mobile app, website, or both? Count on Mooseworks Software to collaborate with you at every stage of the project lifecycle, from concept to completion to support. ",
					"http://mooseworkssoftware.com/wordpress/wp-content/uploads/2013/11/services1.png"),
				new Product("Graph", "Product", true,
					"The Graph Control provides every graphing feature you could want: Legends, Zooming, Date/Time, Logarithmic, Inverted axes, Right and Left Y-Axes, Markers, Cursor Values, Alarms, and more, while still providing excellent performance.", 
					"http://mooseworkssoftware.com/wordpress/wp-content/uploads/2013/12/graphimage.png"),
				new Product("Instrumentation", "Product", false,
					"The Instrumentation Control suite includes everything you need to create eye catching and easy to use displays.",
					"http://mooseworkssoftware.com/wordpress/wp-content/uploads/2013/11/Screenshot1.png"),
				new Product("Trend Graph", "Product",  true,
					"The Trend Graph Control provides real time, scrollable charting capabilities. Memory is handled by the Trend Graph’s circular buffer, so you can add points in real time without worrying about memory growing out of control as time goes on. ", 
					"http://mooseworkssoftware.com/wordpress/wp-content/uploads/2013/12/TrendGraph2.png")
			};

			database.InsertAll (products);
			DisplayAlert ("Success", "Database Written", "OK", "");
		}

		private void ReadDatabase(TableRoot TableRoot)
		{
			List<Product> productsList = GetProducts ();

			/*TableSection sectionServices = new TableSection("Services");
			TableSection sectionProducts = new TableSection("Products");

			foreach (Product product in productsList)
			{
				if (product.Category == "Service")
				{
					sectionServices.Add(new ImageCell
						{
							ImageSource = product.ImageUrl,
							Text = product.Name,
							TextColor = Color.Black,
							Detail = product.Description,
							DetailColor = Color.Navy
						});
				}
				else
				{
					sectionProducts.Add(new ImageCell
						{
							ImageSource = product.ImageUrl,
							Text = product.Name,
							TextColor = Color.Black,
							Detail = product.Description,
							DetailColor = Color.Navy
						});
				}
			}
			TableRoot.Add(new TableSection[]{sectionServices, sectionProducts});*/
		}

		private List<Product> GetProducts ()
		{
			return database.Query<Product> ("select * from product where Category='Service'");
			//return database.Table<Product>().Select(p => p).ToList ();

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
			return Name;
		}
	}

}

