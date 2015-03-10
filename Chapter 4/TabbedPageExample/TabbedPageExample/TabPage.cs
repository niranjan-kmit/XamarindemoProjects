using System;
using Xamarin.Forms;

namespace TabbedPageExample
{
	public class TabPage : TabbedPage
	{
		public TabPage ()
		{
			this.Title = "Tabbed Page";
			this.Children.Add (new ContentPage1 ());
			this.Children.Add (new ContentPage2 ());
		}

		protected override void OnCurrentPageChanged ()
		{
			base.OnCurrentPageChanged ();
			if (CurrentPage is ContentPage2) {
		ContentPage2 page2 = (ContentPage2)CurrentPage;
		page2.LabelText = "Showing Second Page";
		} 
		else
			{
				ContentPage1 page1 = (ContentPage1)CurrentPage;
				page1.LabelText = "showing first one";

			}
		}

	}
}

