using System;
using MonoTouch.UIKit;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.IOS.TableSources
{
	public class ContactDetailsTableSource:UITableViewSource
	{
		string cellIdentifier = "contactDetailsCell";

		Person Contact;

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 2;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Value2, cellIdentifier);

			switch (indexPath.Row) {
			case 0:
				cell.TextLabel.Text = "First Name";
				cell.DetailTextLabel.Text = Contact.FirstName;
				break;
			case 1:
				cell.TextLabel.Text = "Last Name";
				cell.DetailTextLabel.Text = Contact.LastName;
				break;
			}

			return cell;
		}

		#endregion

		public ContactDetailsTableSource (Person contact)
		{
			this.Contact = contact;
		}
	}
}

