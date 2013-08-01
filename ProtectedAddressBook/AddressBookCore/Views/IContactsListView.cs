using System;
using System.Collections.Generic;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Core.Views
{
	public interface IContactsListView:IMediatorTarget
	{
		event EventHandler ContactSelected;

		List<Person> Contacts{ get; set; }

		Person SelectedContact{get;}

		void GoContactDetails();
	}
}

