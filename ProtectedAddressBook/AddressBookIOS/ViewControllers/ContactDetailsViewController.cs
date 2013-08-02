using System;
using MonoTouch.UIKit;
using MonkeyArms.LockedAddressBook.Core.Views;
using MonkeyArms.LockedAddressBook.Core.Models;
using MonkeyArms.LockedAddressBook.IOS.TableSources;

namespace MonkeyArms.LockedAddressBook.IOS.ViewControllers
{
	public class ContactDetailsViewController:UIViewController, IContactDetailsView
	{
		UITableView TableView;

		#region IContactDetailsView implementation

		private Person contact;
		public Person SelectedContact {
			get {
				return contact;
			}
			set {
				this.contact = value;
				UpdateTableSource ();
			}
		}

		#endregion

		public ContactDetailsViewController ()
		{
			this.Title = "Details";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			BuildUI ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			DI.RequestMediator (this);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			DI.DestroyMediator (this);
		}

		void BuildUI ()
		{
			TableView = new UITableView (View.Bounds, UITableViewStyle.Grouped);
			View.AddSubview (TableView);
			UpdateTableSource ();
		}

		void UpdateTableSource ()
		{
			if (TableView != null && SelectedContact != null) {
				TableView.Source = new ContactDetailsTableSource (SelectedContact);
			}
		}
	}
}

