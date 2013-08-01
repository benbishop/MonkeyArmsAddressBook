using System;
using NUnit.Framework;
using MonkeyArms.LockedAddressBook.Core.Commands;
using Moq;
using MonkeyArms.LockedAddressBook.Core.ViewModels;
using MonkeyArms.LockedAddressBook.Core.Models;
using MonkeyArms.LockedAddressBook.Core.Invokers;

namespace MonkeyArms.LockedAddressBook.Tests.Commands
{
	[TestFixture()]
	public class SetSelectedContactCommandTests
	{
		Mock<ContactDetailsViewModel> MockVM;

		SetSelectedContactCommand Command;

		[SetUp]
		public void Init()
		{
			MockVM = new Mock<ContactDetailsViewModel> ();
			Command = new SetSelectedContactCommand ();
			Command.VM = MockVM.Object;
		}


		[Test()]
		public void TestCase ()
		{
			var contact = new Person ("john", "joe");
			Command.Execute (new SelectContactInvokerArgs(contact));
			MockVM.VerifySet (vm => vm.SelectedContact = contact, Times.Once ());
		}
	}
}

