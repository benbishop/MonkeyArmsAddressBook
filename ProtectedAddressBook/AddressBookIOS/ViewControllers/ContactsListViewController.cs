using System;
using MonoTouch.UIKit;
using MonkeyArms.LockedAddressBook.Core.Views;
using System.Collections.Generic;
using MonkeyArms.LockedAddressBook.Core.Models;
using MonkeyArms.LockedAddressBook.IOS.TableSources;

namespace MonkeyArms.LockedAddressBook.IOS.ViewControllers
{
	public class ContactsListViewController:UITableViewController, IContactsListView
	{
		#region IContactsListView implementation
		public event EventHandler ContactSelected = delegate {};
		public void GoContactDetails ()
		{
			NavigationController.PushViewController (new ContactDetailsViewController (), true);
		}

		private List<Person> contacts;
		public System.Collections.Generic.List<MonkeyArms.LockedAddressBook.Core.Models.Person> Contacts {
			get {
				return contacts;
			}
			set {
				contacts = value;

				var contactsListTableSource = new ContactsListTableSource (contacts);
				contactsListTableSource.ItemSelected += (object sender, EventArgs e) => {
					selectedContact = contacts[contactsListTableSource.SelectedRowIndex];
					ContactSelected(this, EventArgs.Empty);
				};
				this.TableView.Source = contactsListTableSource;


			}
		}

		private Person selectedContact;
		public MonkeyArms.LockedAddressBook.Core.Models.Person SelectedContact {
			get {
				return selectedContact;
			}
		}
		#endregion

		public ContactsListViewController ()
		{
			this.Title = "Contacts";
		}

	

		public override void ViewWillAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			DI.RequestMediator (this);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			DI.DestroyMediator (this);
		}


	}
}

