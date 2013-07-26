using System;
using NUnit.Framework;
using MonkeyArms.LockedAddressBook.Core.Models;

namespace MonkeyArms.LockedAddressBook.Tests.Models
{
	[TestFixture("John", "Doe")]
	[TestFixture("Jane", "Smith")]
	public class PersonModelTests
	{
		string TestFirstName, TestLastName;

		Person TestModel;

		public PersonModelTests(string firstName, string lastName)
		{
			TestFirstName = firstName;
			TestLastName = lastName;
		}

		[SetUp]
		public void Init()
		{
			this.TestModel = new Person (TestFirstName, TestLastName);
		}

		[Test]
		public void assert_FirstName_gets_set_via_constructor()
		{
			Assert.AreEqual (TestFirstName, TestModel.FirstName);
		}

		[Test]
		public void assert_LastName_gets_set_via_constructor()
		{
			Assert.AreEqual (TestLastName, TestModel.LastName);
		}
	}
}

