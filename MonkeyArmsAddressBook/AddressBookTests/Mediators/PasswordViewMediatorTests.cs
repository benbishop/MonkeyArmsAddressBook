using System;
using NUnit.Framework;
using Moq;
using MonkeyArms.AddressBook.Core.Views;
using MonkeyArms.AddressBook.Core.Mediators;

namespace MonkeyArms.AddressBook.Tests.Mediators
{
	[TestFixture()]
	public class PasswordViewMediatorTests
	{
		Mock<IPasswordView> MockView;

		PasswordViewMediator Mediator;

		[SetUp]
		public void Init()
		{
			MockView = new Mock<IPasswordView> ();
			Mediator = new PasswordViewMediator (MockView.Object);
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
	}
}

