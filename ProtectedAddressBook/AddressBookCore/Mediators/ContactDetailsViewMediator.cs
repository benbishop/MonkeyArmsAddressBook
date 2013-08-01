using System;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.ViewModels;

namespace MonkeyArms.LockedAddressBook.Core.Mediators
{
	public class ContactDetailsViewMediator:Mediator
	{
		[Inject]
		public ContactDetailsViewModel VM;


		protected IContactDetailsView View;

		public ContactDetailsViewMediator (IMediatorTarget target):base(target)
		{
			View = target as IContactDetailsView;
		}

		#region implemented abstract members of Mediator

		public override void Register ()
		{
			VM.ContactChanged += HandleContactChanged;
			View.SelectedContact = VM.SelectedContact;
		}

		public override void Unregister ()
		{
			VM.ContactChanged -= HandleContactChanged;
		}

		void HandleContactChanged (object sender, EventArgs e)
		{
			View.SelectedContact = VM.SelectedContact;
		}

		#endregion
	}
}

