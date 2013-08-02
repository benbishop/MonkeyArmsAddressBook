using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Models;
using MonkeyArms.LockedAddressBook.Android.Adapters;

namespace MonkeyArms.LockedAddressBook.Android
{
	[Activity (Label = "ContactsListActivity")]			
	public class ContactsListActivity : Activity, IContactsListView
	{

		protected ListView ContactsListView;

		#region IContactsListView implementation

		public event EventHandler ContactSelected;

		public void GoContactDetails ()
		{
			StartActivity (typeof(ContactDetailsActivity));
		}

		private List<Person> contacts;

		public List<Person> Contacts {
			get {
				return contacts;
			}
			set {
				contacts = value;
				UpdateListView ();
			}
		}

		private Person selectedContact;
		public Person SelectedContact {
			get {
				return selectedContact;
			}
		}

		#endregion

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ContactsListLayout);
			ContactsListView = FindViewById (Resource.Id.contactsListView) as ListView;
			ContactsListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				selectedContact = contacts[e.Position];
				ContactSelected(this, EventArgs.Empty);
			};

			UpdateListView ();
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

		void UpdateListView ()
		{
			if (ContactsListView != null && contacts != null) {
				ContactsListView.Adapter = new ContactsListAdapter (this, contacts);
			}
		}
	}
}

