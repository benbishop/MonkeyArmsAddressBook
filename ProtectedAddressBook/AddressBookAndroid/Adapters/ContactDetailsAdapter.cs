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

using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Android.Adapters
{
	class ContactDetailsAdapter:BaseAdapter<Person>
	{
		protected Activity Context;
		protected Person Contact;

		public ContactDetailsAdapter(Activity context, Person contact):base()
		{
			this.Context = context;
			this.Contact = contact;
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null) {
				view = this.Context.LayoutInflater.Inflate (Resource.Layout.ContactDetailItem, null);
			}

			var labelView = view.FindViewById (Resource.Id.labelTextView) as TextView;
			var valueView = view.FindViewById (Resource.Id.valueTextView) as TextView;

			switch (position) {
			case 0:
				labelView.Text = this.Context.GetString (Resource.String.firstNameLabel);
				valueView.Text = Contact.FirstName;
				break;

			case 1:
				labelView.Text = this.Context.GetString (Resource.String.lastNameLabel);
				valueView.Text = Contact.LastName;
				break;
			default:

				break;
			}
			return view;
		}

		public override int Count {
			get {
				return 2;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Person this [int index] {
			get {
				return Contact;
			}
		}

		#endregion
	}
}

