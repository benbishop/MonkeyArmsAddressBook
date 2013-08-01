using System;
using NUnit.Framework;
using Moq;
using MonkeyArms.LockedAddressBook.Core.Commands;
using MonkeyArms.LockedAddressBook.Core.ViewModels;

namespace MonkeyArms.LockedAddressBook.Tests.Commands
{
	[TestFixture()]
	public class GetContactsCommandTests
	{
		Mock<IGetContactsDelegate> MockGetContactsDelegate;

		Mock<ContactsListViewModel> MockVM;

		GetContactsCommand Command;

		[SetUp]
		public void Init()
		{
			MockGetContactsDelegate = new Mock<IGetContactsDelegate> ();
			Command = new GetContactsCommand ();
			Command.ContactsDelegate = MockGetContactsDelegate.Object;
			MockVM = new Mock<ContactsListViewModel> ();
			Command.VM = MockVM.Object;
		}


		[Test]
		public void assert_command_sets_contacts_list_on_VM_when_PersonAccessed_is_raised_from_delegate ()
		{
			Command.Execute (null);
			MockGetContactsDelegate.Raise (d => d.PersonsAccessed += null, EventArgs.Empty);
			MockVM.VerifySet (vm => vm.Contacts, Times.Once());
		}
	}
}

