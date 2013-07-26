using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Contacts;
using System.Text;

namespace MonkeyArms.LockedAddressBook.IOS.Commands
{
	public class GetContactsCommand:Command
	{
		public GetContactsCommand ()
		{
		}

		#region implemented abstract members of Command

		public override void Execute (InvokerArgs args)
		{
			var abook = new AddressBook();


			abook.RequestPermission().ContinueWith (t =>
			                                         {
				if (!t.Result)
					return; // Permission denied

				var builder = new StringBuilder();

				// Full LINQ support
				foreach (Contact c in abook.Where (c => c.FirstName == "Eric" && c.Phones.Any()))
				{
					builder.AppendLine (c.DisplayName);
					foreach (Phone p in c.Phones)
						builder.AppendLine (String.Format ("{0}: {1}", p.Label, p.Number));

					builder.AppendLine();
				}



			}, TaskScheduler.FromCurrentSynchronizationContext()); // Ensure we're on the UI Thread

		}

		#endregion
	}
}

