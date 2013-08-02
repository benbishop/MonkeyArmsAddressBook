using System;
using MonoTouch.UIKit;
using MonkeyArms.LockedAddressBook.Core.Views;
using System.Drawing;

namespace MonkeyArms.LockedAddressBook.IOS.ViewControllers
{
	public class PasswordViewController:UIViewController, IPasswordView
	{
		UITextField PasswordTextField;

		UIButton SubmitButton;

		#region IPasswordView implementation

		public event EventHandler PasswordSubmitted;

		public void ShowIncorrectPasswordPrompt ()
		{
			var alert = new UIAlertView("Password Incorrect", "Sorry the password submitted is incorrect.", null, "OK", null);
			alert.Show();
		}

		public void UnLock ()
		{
			this.NavigationController.PushViewController (new ContactsListViewController (), true);
		}

		public string Password {
			get {
				return PasswordTextField.Text;
			}
		}

		#endregion

		public PasswordViewController ():base()
		{
			this.View.BackgroundColor = UIColor.Gray;
			this.Title = "Enter Password";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			BuildUI ();
			AddEventListeners ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			DI.RequestMediator (this);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			DI.DestroyMediator (this);
		}

		void BuildUI ()
		{
			const int itemHeight = 50;
			const int padding = 10;

			var itemWidth = View.Bounds.Width - (padding * 2);

			PasswordTextField = new UITextField (new RectangleF (padding, padding, itemWidth, itemHeight));
			PasswordTextField.SecureTextEntry = true;
			PasswordTextField.BorderStyle = UITextBorderStyle.Bezel;
			PasswordTextField.BackgroundColor = UIColor.White;
			PasswordTextField.Placeholder = "Password";
			PasswordTextField.ReturnKeyType = UIReturnKeyType.Done;
			View.AddSubview (PasswordTextField);

			SubmitButton = UIButton.FromType (UIButtonType.RoundedRect);
			var buttonY = PasswordTextField.Frame.Y + PasswordTextField.Frame.Height + padding;
			SubmitButton.Frame = new RectangleF (padding, buttonY, itemWidth, itemHeight);
			SubmitButton.SetTitle ("Submit", UIControlState.Normal);
			View.AddSubview (SubmitButton);


		}

		void AddEventListeners ()
		{
			PasswordTextField.ShouldReturn = delegate {
				PasswordTextField.ResignFirstResponder ();
				return true;
			};

			SubmitButton.TouchUpInside += (object sender, EventArgs e) => {
				PasswordSubmitted(this, EventArgs.Empty);
			};
		}
	}
}

