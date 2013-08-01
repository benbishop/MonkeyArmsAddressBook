using System;
using MonkeyArms.LockedAddressBook.Core.ViewModels;

namespace MonkeyArms.LockedAddressBook.Core.Commands
{
	public class GetContactsCommand:Command
	{
		[Inject]
		public IGetContactsDelegate ContactsDelegate;

		[Inject]
		public ContactsListViewModel VM;

		public GetContactsCommand ()
		{
			//since this is an async operation we want to detain the command to avoid GC
			Detain ();
		}

		#region implemented abstract members of Command

		public override void Execute (InvokerArgs args)
		{

			ContactsDelegate.PersonsAccessed += (object sender, EventArgs e) => {
				VM.Contacts = ContactsDelegate.Persons;
				//now that our operation is done we release this command so it can be GC'd
				Release();
			};
			ContactsDelegate.Execute ();
		}

		#endregion
	}
}

