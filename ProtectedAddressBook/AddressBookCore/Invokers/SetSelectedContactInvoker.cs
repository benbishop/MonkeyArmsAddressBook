using System;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Core.Invokers
{
	public class SetSelectedContactInvoker:Invoker
	{
		public SetSelectedContactInvoker ()
		{
		}
	}

	public class SelectContactInvokerArgs:InvokerArgs{

		private Person contact;

		public Person Contact {
			get {
				return contact;
			}
		}

		public SelectContactInvokerArgs(Person contact)
		{
			this.contact = contact;
		}
	}
}

