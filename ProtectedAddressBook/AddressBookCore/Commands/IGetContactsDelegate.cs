using System;
using System.Collections.Generic;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Core.Commands
{
	public interface IGetContactsDelegate
	{
		event EventHandler PersonsAccessed;

		List<Person> Persons{ get;}

		void Execute();
	}
}

