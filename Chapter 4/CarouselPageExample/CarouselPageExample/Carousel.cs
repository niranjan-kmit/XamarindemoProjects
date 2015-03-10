using System;
using Xamarin.Forms;

namespace CarouselPageExample
{
	public class Carousel : CarouselPage
	{
		public Carousel ()
		{
			this.Title = "Carousel Page";
			this.Children.Add (new ContentPage1 ());
			this.Children.Add (new ContentPage2 ());
			this.Children.Add (new ContentPage3 ());
		}

		protected override void OnCurrentPageChanged ()
		{
			base.OnCurrentPageChanged ();
			if (CurrentPage is ContentPage2) 
			{
				ContentPage2 page2 = (ContentPage2)CurrentPage;
				page2.LabelText = "Showing Second Page";

              
			}

		}

	}
}

