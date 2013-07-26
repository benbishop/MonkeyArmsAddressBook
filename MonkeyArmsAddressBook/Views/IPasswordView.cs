using System;

namespace MonkeyArms.LockedAddressBook.Core.Views
{
	public interface IPasswordView:IMediatorTarget
	{
		event EventHandler PasswordSubmitted;

		string Password{get;}

		void ShowIncorrectPasswordPrompt();

		void UnLock();
	}
}

