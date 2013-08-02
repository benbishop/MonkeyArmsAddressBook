using System;
using MonkeyArms.LockedAddressBook.Core.ViewModels;
using MonkeyArms.LockedAddressBook.Core.Invokers;

namespace MonkeyArms.LockedAddressBook.Core.Commands
{
	public class SetSelectedContactCommand:Command
	{
		[Inject]
		public ContactDetailsViewModel VM;

		#region implemented abstract members of Command

		public override void Execute (InvokerArgs args)
		{
			VM.SelectedContact = (args as SelectContactInvokerArgs).Contact;
		}

		#endregion
	}
}

