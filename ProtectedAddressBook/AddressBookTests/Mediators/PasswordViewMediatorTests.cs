using System;
using NUnit.Framework;
using Moq;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Mediators;
using MonkeyArms.LockedAddressBook.Core.Invokers;

namespace MonkeyArms.LockedAddressBook.Tests.Mediators
{
	[TestFixture()]
	public class PasswordViewMediatorTests
	{
		Mock<IPasswordView> MockView;

		PasswordViewMediator Mediator;

		Mock<GetContactsInvoker> MockInvoker;

		[SetUp]
		public void Init()
		{
			MockView = new Mock<IPasswordView> ();
			Mediator = new PasswordViewMediator (MockView.Object);
			MockInvoker = new Mock<GetContactsInvoker> ();
			Mediator.GetContactsInvoker = MockInvoker.Object;
			Mediator.Register ();

		}

		[Test]
		public void assert_ShowIncorrectPasswordPrompt_invoked_when_LoginSubmitted_raised_with_bad_password ()
		{
			MockView.Raise (view => view.PasswordSubmitted += null, EventArgs.Empty);
			MockView.Verify (view => view.ShowIncorrectPasswordPrompt(), Times.Once());
		}

		[Test]
		public void assert_UnLock_invoked_when_LoginSubmitted_raised_with_good_password()
		{
			MockView.SetupGet (view => view.Password).Returns("letmein");
			MockView.Raise (view => view.PasswordSubmitted += null, EventArgs.Empty);
			MockView.Verify (view => view.UnLock(), Times.Once());
		}

		[Test]
		public void assert_GetContactsInvoker_invoked_when_password_is_valid()
		{
			MockView.SetupGet (view => view.Password).Returns("letmein");
			MockView.Raise (view => view.PasswordSubmitted += null, EventArgs.Empty);
			MockInvoker.Verify (i => i.Invoke (null), Times.Once ());
		}
	}
}

