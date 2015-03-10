using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TabbedPageExample
{	
	public partial class ContentPage1 : ContentPage
	{	
		public ContentPage1 ()
		{
			InitializeComponent ();
		}
		public string LabelText {
			get{ return firstpage.Text; }
			set{ firstpage.Text = value; }
		        }
	}
}

