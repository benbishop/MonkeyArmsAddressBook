using System;
using NUnit.Framework;
using Moq;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Mediators;
using MonkeyArms.LockedAddressBook.Core.ViewModels;

namespace MonkeyArms.LockedAddressBook.Tests.Mediators
{
	[TestFixture()]
	public class ContactDetailsViewMediatorTests
	{
		Mock<IContactDetailsView> MockView;

		ContactDetailsViewMediator Mediator;

		Mock<ContactDetailsViewModel> MockViewModel;

		[SetUp]
		public void Init()
		{
			MockView = new Mock<IContactDetailsView> ();
			MockViewModel = new Mock<ContactDetailsViewModel> ();
			Mediator = new ContactDetailsViewMediator (MockView.Object);
			Mediator.VM = MockViewModel.Object;
			Mediator.Register ();
		}

		[Test]
		public void assert_register_method_in_mediator_calls_selected_contact_setter_on_view ()
		{
			MockView.VerifySet (v => v.SelectedContact, Times.Once ());
		}

		[Test]
		public void assert_when_vm_raises_contact_changed_event_setter_for_contact_on_view_is_invoked()
		{
			MockViewModel.Raise (vm => vm.ContactChanged += null, EventArgs.Empty);
			MockView.VerifySet (v => v.SelectedContact, Times.Exactly (2));
		}

		[Test]
		public void assert_when_unregister_is_invoked_on_mediator_it_stops_listening_to_change_event()
		{
			Mediator.Unregister ();
			MockViewModel.Raise (vm => vm.ContactChanged += null, EventArgs.Empty);
			MockView.VerifySet (v => v.SelectedContact, Times.Exactly (1));
		}
	}
}

