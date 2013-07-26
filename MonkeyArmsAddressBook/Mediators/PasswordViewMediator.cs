using System;
using MonkeyArms.AddressBook.Core.Views;

namespace MonkeyArms.AddressBook.Core.Mediators
{
	public class PasswordViewMediator:Mediator
	{

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
			}
		}
	}
}

