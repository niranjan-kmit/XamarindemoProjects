using System;
using System.Collections.Generic;

namespace JsonWriteExample
{
	public class ContactsResult
	{
		public List<Contact>GetContactsResult{ get; set; }
	}

	public class Contact
	{
		public Contact ()
		{
		}

		public int ID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string DisplayName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Picture { get; set; }

	}
}

