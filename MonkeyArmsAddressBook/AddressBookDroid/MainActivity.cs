using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonkeyArms.LockedAddressBook.Delegates;
using Xamarin.Contacts;

namespace MonkeyArms.LockedAddressBook.Android
{
	[Activity (Label = "AddressBookDroid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			GetContactsDelegate.ABook = new AddressBook(this.ApplicationContext);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


