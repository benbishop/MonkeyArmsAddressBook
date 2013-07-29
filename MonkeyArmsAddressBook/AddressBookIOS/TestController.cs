using System;
using MonoTouch.UIKit;

namespace MonkeyArms.LockedAddressBook.IOS
{
	public class TestController:UITableViewController
	{
		public TestController ()
		{
			var l = new List<string> ();
		}

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			base.RowSelected (tableView, indexPath);
		}
	}
}

