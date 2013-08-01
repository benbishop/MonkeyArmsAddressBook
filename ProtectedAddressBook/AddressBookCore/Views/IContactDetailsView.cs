using System;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Core.Views
{
	public interface IContactDetailsView:IMediatorTarget
	{
		Person SelectedContact{ get; set; }
	}
}

