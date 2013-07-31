using System;

namespace MonkeyArms.LockedAddressBook.Core.Models
{
	public class Person
	{

		string _firstName;

		public string FirstName {
			get {
				return _firstName;
			}
		}

		string _lastName;

		public string LastName {
			get {
				return _lastName;
			}
		}

		public Person (string firstName, string lastName)
		{
			this._firstName = firstName;
			this._lastName = lastName;
		}
	}
}

