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
	class ContactsListAdapter:BaseAdapter<Person>
	{
		protected Activity Context;

		protected List<Person> Contacts;

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (convertView == null) {
				view = this.Context.LayoutInflater.Inflate (Resource.Layout.ContactListItem, null);
			}

			var label = view.FindViewById (Resource.Id.labelTextView) as TextView;
			label.Text = String.Format("{0}, {1}", Contacts[position].LastName, Contacts [position].FirstName);
			return view;
		}

		public override int Count {
			get {
				return Contacts.Count;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Person this [int index] {
			get {
				return Contacts [index];
			}
		}

		#endregion


		public ContactsListAdapter(Activity context, List<Person> contacts):base()
		{
			this.Context = context;
			Contacts = contacts;
		}


	}
}

