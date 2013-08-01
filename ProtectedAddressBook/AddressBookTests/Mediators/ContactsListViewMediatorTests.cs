using System;
using NUnit.Framework;
using Moq;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Mediators;
using MonkeyArms.LockedAddressBook.Core.ViewModels;
using MonkeyArms.LockedAddressBook.Core.Invokers;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Tests.Mediators
{
	[TestFixture()]
	public class ContactsListViewMediatorTests
	{
		Mock<IContactsListView> MockView;

		ContactsListViewMediator Mediator;

		Mock<ContactsListViewModel> MockViewModel;

		Mock<SetSelectedContactInvoker> MockSetSelectedContactInvoker;

		[SetUp]
		public void Init()
		{
			MockView = new Mock<IContactsListView> ();
			Mediator = new ContactsListViewMediator (MockView.Object);
			MockViewModel = new Mock<ContactsListViewModel> ();
			Mediator.VM = MockViewModel.Object;
			MockSetSelectedContactInvoker = new Mock<SetSelectedContactInvoker> ();
			Mediator.SetSelectedContactInvoker = MockSetSelectedContactInvoker.Object;
			Mediator.Register ();
		}

		[Test]
		public void assert_when_register_invoked_contacts_is_set_on_view_from_vm()
		{
			MockView.VerifySet (v => v.Contacts, Times.AtLeastOnce());
		}

		[Test]
		public void assert_when_contacts_list_in_VM_changes_setter_for_contacts_on_view_is_invoked ()
		{
			MockViewModel.Raise (vm => vm.ContactsChanged += null, EventArgs.Empty);
			//it should be only twice because Register causes set to happen
			MockView.VerifySet (v => v.Contacts, Times.Exactly(2));
		}

		[Test]
		public void assert_after_unregister_invoked_view_is_no_longer_listening_to_change_event()
		{

			Mediator.Unregister ();
			MockViewModel.Raise (vm => vm.ContactsChanged += null, EventArgs.Empty);
			//it should be only once because Register causes set to happen
			MockView.VerifySet (v => v.Contacts, Times.Exactly(1));
		}

		[Test]
		public void assert_when_view_raises_contact_selected_go_details_screen_is_invoked()
		{
			MockView.Raise (v => v.ContactSelected += null, EventArgs.Empty);
			MockView.Verify(v => v.GoContactDetails(), Times.Once());
		}

		[Test]
		public void assert_when_view_raies_contact_selected_SetSelectedContactInvoker_gets_invoked()
		{
			var testContact = new Person ("john", "doe");
			MockView.SetupGet (v => v.SelectedContact).Returns (testContact);
			MockView.Raise (v => v.ContactSelected += null, EventArgs.Empty);
			MockSetSelectedContactInvoker.Verify (i => i.Invoke (It.Is<SelectContactInvokerArgs>(args => (args.Contact == testContact))), Times.Once ());
		}
	}
}

