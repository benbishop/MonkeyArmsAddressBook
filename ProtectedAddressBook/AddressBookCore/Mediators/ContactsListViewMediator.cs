using System;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.ViewModels;
using MonkeyArms.LockedAddressBook.Core.Invokers;

namespace MonkeyArms.LockedAddressBook.Core.Mediators
{
	public class ContactsListViewMediator:Mediator
	{
		[Inject]
		public ContactsListViewModel VM;

		[Inject]
		public SetSelectedContactInvoker SetSelectedContactInvoker;

		protected IContactsListView View;

		public ContactsListViewMediator (IMediatorTarget contactsListView):base(contactsListView)
		{
			this.View = contactsListView as IContactsListView;
		}

		#region implemented abstract members of Mediator

		public override void Register ()
		{
			VM.ContactsChanged += HandleContactsChanged;
			View.ContactSelected += HandleContactSelected;
			HandleContactsChanged (null, null);
		}

		void HandleContactSelected (object sender, EventArgs e)
		{
			SetSelectedContactInvoker.Invoke (new SelectContactInvokerArgs (View.SelectedContact));
			View.GoContactDetails ();
		}

		void HandleContactsChanged (object sender, EventArgs e)
		{
			View.Contacts = VM.Contacts;
		}

		public override void Unregister ()
		{

			VM.ContactsChanged -= HandleContactsChanged;
			View.ContactSelected -= HandleContactSelected;
		}

		#endregion
	}
}

