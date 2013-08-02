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
	[Activity (Label = "ContactDetailsActivity")]			
	public class ContactDetailsActivity : Activity, IContactDetailsView
	{

		protected ListView DetailsListView;

		#region IContactDetailsView implementation

		private Person contact;
		public Person SelectedContact {
			get {
				return contact;
			}
			set {
				contact = value;
				UpdateDetailsListViewAdapter ();
			}
		}

		#endregion

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ContactDetailsList);

			DetailsListView = FindViewById (Resource.Id.contactDetailsListVIew) as ListView;
			UpdateDetailsListViewAdapter ();
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

		protected void UpdateDetailsListViewAdapter()
		{
			if (DetailsListView != null && contact != null) {
				DetailsListView.Adapter = new ContactDetailsAdapter (this, contact);
			}
		}
	}
}

