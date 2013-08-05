using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonkeyArms.LockedAddressBook.Core.Views;
using Android.Content.PM;

namespace MonkeyArms.LockedAddressBook.Android
{
	[Activity (Label = "Log In", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait )]
	public class MainActivity : Activity, IPasswordView
	{

		protected Button SubmitButton;
		protected EditText PasswordEditText;


		#region IPasswordView implementation

		public event EventHandler PasswordSubmitted = delegate {};

		public void ShowIncorrectPasswordPrompt ()
		{
			Toast.MakeText (this.BaseContext, Resource.String.incorrectPassword, ToastLength.Short).Show();
		}

		public void UnLock ()
		{
			StartActivity (typeof(ContactsListActivity));
		}

		public string Password {
			get {
				return PasswordEditText.Text;
			}
		}

		#endregion

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			SubmitButton = FindViewById (Resource.Id.submitButton) as Button;
			PasswordEditText = FindViewById (Resource.Id.passwordText) as EditText;
			SubmitButton.Click += (object sender, EventArgs e) => {
				PasswordSubmitted(this, EventArgs.Empty);
			};
		
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			DI.RequestMediator (this);
		}

		protected override void OnStop ()
		{
			base.OnStop ();
			DI.DestroyMediator (this);
		}
	}
}


