using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.IOS.TableSources
{
	public class ContactsListTableSource:UITableViewSource
	{
		List<Person> Contacts;

		string cellIdentifier = "contactListItem";

		public event EventHandler ItemSelected = delegate{};

		public int SelectedRowIndex;

		public ContactsListTableSource (List<Person> contacts)
		{
			this.Contacts = contacts;
		}




		#region implemented abstract members of UITableViewSource
		public override int RowsInSection (UITableView tableview, int section)
		{
			return Contacts.Count;
		}
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = String.Format ("{0}, {1}", Contacts [indexPath.Row].LastName, Contacts [indexPath.Row].FirstName);
			return cell;
		}
		#endregion

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			SelectedRowIndex = indexPath.Row;
			ItemSelected (this, EventArgs.Empty);
		}
	}
}

