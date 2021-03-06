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
			View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromBundle ("Images/background/app_background"));





			const int itemHeight = 50;
			const int padding = 10;

			var logo = new UIImageView (new RectangleF(View.Bounds.Width/2 - 191/2, padding, 191, 226));
			logo.Image = UIImage.FromBundle ("Images/logos/mono");
			View.AddSubview (logo);



			var itemWidth = View.Bounds.Width - (padding * 2);

			PasswordTextField = new UITextField (new RectangleF (padding, logo.Frame.Y + logo.Frame.Height + padding, itemWidth, itemHeight));
			PasswordTextField.Font = UIFont.FromName ("Helvetica", 24f);
			PasswordTextField.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			PasswordTextField.SecureTextEntry = true;
			PasswordTextField.BorderStyle = UITextBorderStyle.Bezel;
			PasswordTextField.BackgroundColor = UIColor.White;
			PasswordTextField.Placeholder = "Password";
			PasswordTextField.ReturnKeyType = UIReturnKeyType.Done;
			View.AddSubview (PasswordTextField);

			SubmitButton = UIButton.FromType (UIButtonType.RoundedRect);
			var buttonY = PasswordTextField.Frame.Y + PasswordTextField.Frame.Height + padding;
			SubmitButton.Frame = new RectangleF (padding, buttonY, itemWidth, itemHeight);
			SubmitButton.SetTitleColor (UIColor.White, UIControlState.Normal);
			SubmitButton.Font = UIFont.FromName ("Helvetica-Bold", 20f);
			SubmitButton.SetTitle ("Submit", UIControlState.Normal);
			SubmitButton.SetBackgroundImage (UIImage.FromBundle ("Images/background/OrangeButtonBackground"), UIControlState.Normal);
			View.AddSubview (SubmitButton);


		}

		void AddEventListeners ()
		{
			PasswordTextField.EditingDidBegin += (object sender, EventArgs e) => {
				SlideContent(-200);


			};


			PasswordTextField.ShouldReturn = delegate {
				SlideContent(0);
				PasswordTextField.ResignFirstResponder ();
				return true;
			};

			SubmitButton.TouchUpInside += (object sender, EventArgs e) => {
				PasswordSubmitted(this, EventArgs.Empty);
			};
		}

		protected void SlideContent(int offset)
		{
			UIView.BeginAnimations ("slideContent");
			UIView.SetAnimationDuration (.5);
			UIView.SetAnimationCurve (UIViewAnimationCurve.EaseOut);
			View.Frame = new RectangleF (0, offset, View.Bounds.Width, View.Bounds.Height);
			UIView.CommitAnimations ();
		}
	}
}

