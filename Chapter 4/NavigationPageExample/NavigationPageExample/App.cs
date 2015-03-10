using System;
using Xamarin.Forms;

namespace NavigationPageExample
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage(new NavPage ());
		}
	}
}

