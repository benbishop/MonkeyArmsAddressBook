using System;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Core.ViewModels
{
	public class ContactDetailsViewModel
	{

		public virtual event EventHandler ContactChanged;

		private Person selectedContact;

		public Person SelectedContact {
			get {
				return selectedContact;
			}
			set {
				selectedContact = value;
				ContactChanged (this, EventArgs.Empty);
			}
		}

		public ContactDetailsViewModel ()
		{
		}
	}
}

