using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Contacts;
using System.Text;
using MonkeyArms.LockedAddressBook.Core.Commands;
using System.Collections.Generic;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Delegates
{
	public class GetContactsDelegate:IGetContactsDelegate
	{
		public GetContactsDelegate ()
		{
		}

		#region IGetContactsCommand implementation
		public event EventHandler PersonsAccessed = delegate {};


		private List<Person> _persons;
		public List<Person> Persons {
			get {
				return _persons;
			}
		}
		#endregion



		public void Execute ()
		{
			var abook = new AddressBook();


			abook.RequestPermission().ContinueWith (t =>
			                                         {
				if (!t.Result)
					return; // Permission denied

				_persons = new List<Person>();

				// Full LINQ support
				foreach (Contact c in abook)
				{
					_persons.Add(new Person(c.FirstName, c.LastName));
				}

				PersonsAccessed(this, EventArgs.Empty);

			}, TaskScheduler.FromCurrentSynchronizationContext()); // Ensure we're on the UI Thread

		}


	}
}

