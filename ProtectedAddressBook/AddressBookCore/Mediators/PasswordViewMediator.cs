using System;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Invokers;

namespace MonkeyArms.LockedAddressBook.Core.Mediators
{
	public class PasswordViewMediator:Mediator
	{

		[Inject]
		public GetContactsInvoker GetContactsInvoker;

		protected IPasswordView View;

		public PasswordViewMediator (IPasswordView target):base( target as IMediatorTarget)
		{
			this.View = target;
		}


		#region implemented abstract members of Mediator

		public override void Register ()
		{
			View.PasswordSubmitted += HandlePasswordSubmitted;
		}


		public override void Unregister ()
		{
			View.PasswordSubmitted -= HandlePasswordSubmitted;
		}

		#endregion

		void HandlePasswordSubmitted (object sender, EventArgs e)
		{
			if (View.Password != "letmein") {
				View.ShowIncorrectPasswordPrompt ();
			} else {
				View.UnLock ();
				GetContactsInvoker.Invoke (null);
			}
		}
	}
}

